with config;use config;
with controllers;use controllers;
with single_tracks;use single_tracks;
with platforms;use platforms;
with Ada.Numerics.Float_Random;use Ada.Numerics.Float_Random;

package trains is

   type Controller_Access is access all Controller_Task;
   type Track_Access is access all Single_Track;
   type Platform_Access is access all Platform_Type;

   task type Train_T(Station_Controller:Controller_Access;Track:Track_Access;Station_Platform:Platform_Access) is
      entry Start(ID:Integer;Kind:Train_T_Type);
   end Train_T;

   procedure Run_Train(ID:Integer;Type_Train:Train_T_Type;Station_Controller:in out Controller_Task;Track:in out Single_Track;Station_Platform:in out Platform_Type);

private

   function assign_times(T:Train_T_Type;G:in out Generator) return Duration;

   procedure Arrival_Train(G:in out Generator;station_controller:in out Controller_Task;track:in out Single_Track;ID:Integer;Type_Train:Train_T_Type);

   procedure Train_Request_Platform(dwell_time:Duration;platform_station:in out Platform_Type;ID:Integer;Type_Train:Train_T_Type);

   procedure Departure_Train(G:in out Generator;station_controller:in out Controller_Task;track:in out Single_Track;ID:Integer;Type_Train:Train_T_Type);

end trains;