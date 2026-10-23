with config; use config;
with controllers; use controllers;
with single_tracks; use single_tracks;
with platforms; use platforms;
with trains; use trains;
with Monitor; use Monitor;
with Ada.Text_IO; use Ada.Text_IO;
with logger; use logger;

procedure main is
   Total_Trains : constant Positive :=
      Num_Trains_Express + Num_Trains_Regional + Num_Trains_Freight;

      my_station_controller : constant Controller_Access := new Controller_Task;
      station_monitor : constant Monitor_Access := new Monitor_Type(my_station_controller);
      my_track : constant Track_Access := new Single_Track(station_monitor);
      my_platform : constant Platform_Access := new Platform_Type(Num_Platforms, Total_Trains, station_monitor);

      subtype Train_Instance is Train_T(my_station_controller,
         my_track,
         my_platform);

   type Train_Task_Array is array (index) of Train_Instance;
   Train_Tasks : Train_Task_Array;

   kind : Train_T_Type;
   element_index : Natural;
begin
   for I in Train_Tasks'Range loop
      element_index := I - Train_Tasks'First;


      if element_index < Num_Trains_Express then
         kind := Express;
      elsif element_index < (Num_Trains_Express + Num_Trains_Regional) then
         kind := Regional;
      else 
         kind := Freight;
      end if;

      Train_Tasks(I).Start(I, kind);
   end loop;

      delay until End_Time;

      Stop(my_track.all);
      my_platform.all.Stop;

      Put_Line("");
      Put_Line("==========================================");
      Put_Line(Time_Stamp & "[ MAIN ] Simulation time reached. Shutting down...");
      Put_Line("==========================================");
      Put_Line("");

end main;

