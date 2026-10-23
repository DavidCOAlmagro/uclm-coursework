with Ada.Real_Time;use Ada.Real_Time;
with Ada.Text_IO; use Ada.Text_IO;

package body trains is

   function assign_times(T:Train_T_Type;G:in out Generator) return Duration is
   begin
      case T is
         when Express=>
            return Duration(Random(G)*2.0+1.0);

         when Regional=>
            return Duration(Random(G)*4.0+2.0);

         when Freight=>
            return Duration(Random(G)*7.0+3.0);
      end case;
   end assign_times;

   procedure Arrival_Train(G:in out Generator;station_controller:in out Controller_Task;track:in out Single_Track;ID:Integer;Type_Train:Train_T_Type) is
   begin
      station_controller.Arrival(ID,Type_Train);
      single_tracks.Request_Track(track,ID,Type_Train,Entering);
      delay until Clock+To_Time_Span(Duration(Random(G)*0.0+1.0));
      single_tracks.Release_Track(track,ID,Type_Train,Entering);
   end Arrival_Train;

   procedure Train_Request_Platform(dwell_time:Duration;platform_station:in out Platform_Type;ID:Integer;Type_Train:Train_T_Type) is
   begin
      platforms.Request_Platform(platform_station,ID,Type_Train);
      delay until Clock+To_Time_Span(dwell_time);
      platforms.Release_Platform(platform_station,ID,Type_Train);
   end Train_Request_Platform;

   procedure Departure_Train(G:in out Generator;station_controller:in out Controller_Task;track:in out Single_Track;ID:Integer;Type_Train:Train_T_Type) is
   begin
      single_tracks.Request_Track(track,ID,Type_Train,Leaving);
      delay until Clock+To_Time_Span(Duration(Random(G)*1.0+1.0));
      single_tracks.Release_Track(track,ID,Type_Train,Leaving);
      station_controller.Departure(ID,Type_Train);
   end Departure_Train;

   procedure Run_Train(ID:Integer;Type_Train:Train_T_Type;Station_Controller:in out Controller_Task;Track:in out Single_Track;Station_Platform:in out Platform_Type) is
      dwell_time:Duration;
      G:Generator;
      Initial_Delay:Duration;
   begin
      Reset(G);

      -- Initial delay to desynchronize trains (0 to 5 seconds)
      Initial_Delay := Duration(Random(G)*5.0);
      delay until Clock+To_Time_Span(Initial_Delay);

      loop -- Simulates the scheduled train(coming back after some time)
         exit when single_tracks.Is_Stopped(Track) or Station_Platform.Is_Stopped;

         dwell_time:=assign_times(Type_Train,G);

         Arrival_Train(G,Station_Controller,Track,ID,Type_Train);
         Train_Request_Platform(dwell_time,Station_Platform,ID,Type_Train);
         Departure_Train(G,Station_Controller,Track,ID,Type_Train);
          -- waits random time before entering again
         delay until Clock + To_Time_Span(Duration(Random(G) * 5.0 + 3.0));
      end loop;
      exception
         when Simulation_Duration_Exceeded =>
            null;
   end Run_Train;

   task body Train_T is
      Train_ID:Integer;
      Train_Kind:Train_T_Type;
   begin
      accept Start(ID:Integer;Kind:Train_T_Type) do
         Train_ID:=ID;
         Train_Kind:=Kind;
      end Start;

      Run_Train(Train_ID,Train_Kind,Station_Controller.all,Track.all,Station_Platform.all);
   end Train_T;

end trains;