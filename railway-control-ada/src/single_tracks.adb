package body single_tracks is
   procedure Stop (T : in out Single_Track) is
   begin
      T.Stop;
   end Stop;

   function Is_Stopped (T : Single_Track) return Boolean is
   begin
      return T.Is_Stopped;
   end Is_Stopped;

   procedure Request_Track (T : in out Single_Track; ID_Train : Integer; 
      train_type : Train_T_Type;  dir : Direction) is
   begin
      if T.Is_Stopped then
         raise Simulation_Duration_Exceeded;
      end if;

      -- Notify monitor that the train requests the section
      if T.station_monitor /= null then
         T.station_monitor.Update_Track (dir, ID_Train, train_type, Requested);
      end if;

      if dir = Entering then
         T.Request_Entry;
      else
         T.Request_Exit;
      end if;

      if T.Is_Stopped then
         raise Simulation_Duration_Exceeded;
      end if;

      -- Notify monitor that the train has entered the section
      if T.station_monitor /= null then
         T.station_monitor.Update_Track (dir, ID_Train, train_type, Entered);
      end if;
   end Request_Track;

   procedure Release_Track (T : in out Single_Track; ID_Train : Integer;
      train_type : Train_T_Type; dir : Direction) is
   begin
      T.Release;

      if T.Is_Stopped then
         raise Simulation_Duration_Exceeded;
      end if;

      -- Notify monitor that the train released the section
      if T.station_monitor /= null then
         T.station_monitor.Update_Track (dir, ID_Train, train_type, Released);
      end if;
   end Release_Track;

   protected body Single_Track is
      procedure Stop is
      begin
         Stopped := True;
      end Stop;

      function Is_Stopped return Boolean is
      begin
         return Stopped;
      end Is_Stopped;

         entry Request_Entry when Stopped or (Current_State = Free
            and (Request_Exit'Count = 0 or Last_Served = Leaving)) is
      begin
         if not Stopped then
            Current_State := Busy;
            Last_Served := Entering;
         end if;
      end Request_Entry;

         entry Request_Exit when Stopped or (Current_State = Free
            and (Request_Entry'Count = 0 or Last_Served = Entering)) is
      begin
         if not Stopped then
            Current_State := Busy;
            Last_Served := Leaving;
         end if;
      end Request_Exit;

      procedure Release is
      begin
         if not Stopped then
            Current_State := Free;
         end if;
      end Release;

   end Single_Track;

end single_tracks;
