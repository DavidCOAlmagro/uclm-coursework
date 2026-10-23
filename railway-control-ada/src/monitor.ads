with config;use config;
with controllers;use controllers;

package Monitor is

   type Track_Event_Type is (Requested,Entered,Released);

   task type Monitor_Type(Station_Controller:access Controller_Task) is
      entry Update_Platforms(dir:Direction;platform_id:Positive;train_id:Integer;train_type:Train_T_Type);

      entry Update_Track(dir:Direction;train_id:Integer;train_type:Train_T_Type;event:Track_Event_Type);
   end Monitor_Type;

   type Monitor_Access is access all Monitor_Type;

   procedure Show_State;

private

   Num_Trains_Platform:Natural:=0;
   Num_Trains_Track:Natural:=0;
   Num_Trains_Completed:Natural:=0;
   Num_Trains_Fully_Departed:Natural:=0;

   type Platform_ID_Array is array(index) of Positive;

   Platform_IDs:Platform_ID_Array:=(others=>Positive'Last);

end Monitor;