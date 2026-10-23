with Ada.Text_IO; use Ada.Text_IO;
with Logger; use Logger;

package body controllers is
   task body Controller_Task is
   begin
      loop
         select
            accept Arrival (train_ID : Integer; train_type : Train_T_Type) do
               Put(Item => Time_Stamp);
               Put(Item => "[ TRAIN ");
               Put(Item => train_type'Image);
               Put(Item => " -");
               Put(Item => train_ID'Image);
               Put_Line("] has arrived");
               total_trains_arrived := total_trains_arrived + 1;
            end Arrival;
         or
            accept Departure (train_ID : Integer; train_type : Train_T_Type) do
               Put(Item => Time_Stamp);
               Put(Item => "[ TRAIN ");
               Put(Item => train_type'Image);
               Put(Item => " -");
               Put(Item => train_ID'Image);
               Put_Line("] has departed");
               total_trains_departed := total_trains_departed + 1;
            end Departure;
         or
            accept Statistics do
               New_Line;

               Put_Line("=========== Current statistics ==========");
               Put_Line("Total trains arrived: " & total_trains_arrived'Image);
               Put_Line("Total trains departed: " & total_trains_departed'Image);
               Put_Line("=========================================");

               New_Line;
            end Statistics;
         or
            delay until End_Time;
            raise Simulation_Duration_Exceeded;
         end select;
      end loop;
   exception
      when Simulation_Duration_Exceeded =>
         null;
   end Controller_Task;
end controllers;
