with Ada.Text_IO;use Ada.Text_IO;
with Ada.Real_Time;use Ada.Real_Time;
with Logger;use Logger;

package body Monitor is
   procedure Show_State is
   begin
      Put_Line("");
      Put_Line("=========== Monitor Report ==========");
      Put_Line("=========== Current state of the station ==========");
      Put_Line("Number of trains in the platform: "&Num_Trains_Platform'Image);
      Put_Line("Number of trains in the track: "&Num_Trains_Track'Image);

      New_Line;
      if Num_Trains_Platform>0 then
         Put("Trains in platforms: ");
         for I in Platform_IDs'Range loop
            if Platform_IDs(I)/=Positive'Last then
               Put(Platform_IDs(I)'Image&" ");
            end if;
         end loop;
         New_Line;
      end if;

      Put_Line("==========================================");
      New_Line;
   end Show_State;

   task body Monitor_Type is
      Next_Update:Time:=Clock+To_Time_Span(Duration(N));
   begin
      loop
         select
            accept Update_Platforms(dir:Direction;platform_id:Positive;train_id:Integer;train_type:Train_T_Type) do
               if dir=Entering then
                  Num_Trains_Platform:=Num_Trains_Platform+1;
                  Platform_IDs(platform_id):=train_id;

                  Put_Line(Time_Stamp&"[ PLATFORM ] "&train_type'Image&" -"&train_id'Image&" enters platform ( direction : ENTRY )");
                  Put_Line(Time_Stamp&"[ TRAIN "&train_type'Image&" -"&train_id'Image&"] Docks at platform "&platform_id'Image);
               else
                  Num_Trains_Platform:=Num_Trains_Platform-1;
                  Num_Trains_Completed:=Num_Trains_Completed+1;
                  Platform_IDs(platform_id):=Positive'Last;

                  Put_Line(Time_Stamp&"[ TRAIN "&train_type'Image&" -"&train_id'Image&"] Releases platform "&platform_id'Image);
               end if;
            end Update_Platforms;

         or

            accept Update_Track(dir:Direction;train_id:Integer;train_type:Train_T_Type;event:Track_Event_Type) do
               declare
                  Direction_Text:constant String:=(if dir=Entering then "ENTRY" else "EXIT");
               begin
                  if event=Requested then
                     Put_Line(Time_Stamp&"[ TRAIN "&train_type'Image&" -"&train_id'Image&"] Requests section ( "&Direction_Text&" )");

                  elsif event=Entered then
                     Num_Trains_Track:=Num_Trains_Track+1;
                     Put_Line(Time_Stamp&"[ SECTION ] "&train_type'Image&" -"&train_id'Image&" enters section ( direction : "&Direction_Text&" )");

                  elsif event=Released then
                     Num_Trains_Track:=Num_Trains_Track-1;
                     if dir=Leaving then
                        Num_Trains_Fully_Departed:=Num_Trains_Fully_Departed+1;
                     end if;
                     Put_Line(Time_Stamp&"[ SECTION ] "&train_type'Image&" -"&train_id'Image&" releases section ( direction : "&Direction_Text&" )");
                  end if;
               end;
            end Update_Track;

         or
            delay until Next_Update;
         or 
            delay until End_Time;
            raise Simulation_Duration_Exceeded;
         end select;

         if Clock>=Next_Update then
            Show_State;
            Station_Controller.Statistics;
            Next_Update:=Clock+To_Time_Span(Duration(N));
         end if;
      end loop;
   exception
      when Simulation_Duration_Exceeded =>
         null;
   end Monitor_Type;
end Monitor;