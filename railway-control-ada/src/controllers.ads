with config; use config;

package controllers is
   task type Controller_Task is
      entry Arrival(train_ID: Integer; train_type : Train_T_Type);
      entry Departure(train_ID: Integer; train_type : Train_T_Type);
      entry Statistics;
   end Controller_Task;

   private 
      total_trains_arrived : Natural := 0;
      total_trains_departed : Natural := 0;
   
end controllers;