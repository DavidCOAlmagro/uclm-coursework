with Ada.Real_Time; use Ada.Real_Time;
package config is
   subtype Platforms_Range is Positive range 2 .. Positive'Last;
   type Train_T_Type is (Express, Regional, Freight);
   type Direction is (Entering, Leaving);

   Num_Trains_Express : Natural := 8;
   Num_Trains_Regional : Natural :=  0;
   Num_Trains_Freight : Natural := 2;
   Num_Platforms : Platforms_Range := 2;
   
   N : Float := 2.0; -- Time between state updates in the monitor
   End_Time : constant Time := Clock + To_Time_Span(Duration(60.0));
   Simulation_Duration_Exceeded : exception;
   subtype index is Integer range 1 .. (Num_Trains_Express + Num_Trains_Regional + Num_Trains_Freight);
end config;