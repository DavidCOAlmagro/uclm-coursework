
package body platforms is
   procedure Request_Platform(p: in out Platform_Type; ID_Train : Integer; train_type : Train_T_Type) is
      id_platform : Integer;
      begin
         if p.Is_Stopped then
            raise Simulation_Duration_Exceeded;
         end if;

         if train_type = Express then
            p.Request_Express(ID_Train, id_platform); 
         elsif train_type = Regional then
            p.Request_Regional(ID_Train, id_platform);
         else
            p.Request_Freight(ID_Train, id_platform);
         end if;

         if p.Is_Stopped then
            raise Simulation_Duration_Exceeded;
         end if;

         -- Notify the monitor with the actual assigned platform.
         -- Fuera del protected: llamada bloqueante al monitor
         p.station_monitor.Update_Platforms(Entering, id_platform, ID_Train, train_type);
      end Request_Platform;

   procedure Release_Platform(p: in out Platform_Type; ID_Train : Integer; train_type : Train_T_Type) is 
      id_platform : Integer;
      begin
         if p.Is_Stopped then
            raise Simulation_Duration_Exceeded;
         end if;

         p.Release(ID_Train, id_platform);

         if p.Is_Stopped then
            raise Simulation_Duration_Exceeded;
         end if;

         -- Fuera del protected: llamada bloqueante al monitor
         p.station_monitor.Update_Platforms(Leaving, id_platform, ID_Train, train_type);
      end Release_Platform;

         
      protected body Platform_Type is
      
         procedure Stop is
         begin
            Stopped := True;
         end Stop;

         function Is_Stopped return Boolean is
         begin
            return Stopped;
         end Is_Stopped;

         procedure Assign_Platform(ID_Train : Integer; platform_id : out Integer) is
         I : Positive := Platform_Free'First;
         found : Boolean := False;
         begin
            platform_id := 0;
            while I <= Platform_Free'Last and not found loop
               if Platform_Free(I) then
                  platform_id := I;
                  Platform_Free(I) := False;
                  Free_platforms := Free_platforms - 1;
                  Assigned_Platforms(ID_Train) := platform_id;
                  found := True;
               end if;
               I := I + 1;
            end loop;
         end Assign_Platform;

            entry Request_Express(ID_Train : Integer; platform_id : out Integer) when Stopped or (Free_platforms > 0 and 
               (Served_Not_Freight < Limit_Freight)) is
         begin
            platform_id := 0;
            if not Stopped then
               Assign_Platform(ID_Train, platform_id);
               Served_Not_Freight := Served_Not_Freight + 1;
            end if;
         end Request_Express;

            entry Request_Regional(ID_Train : Integer; platform_id : out Integer) when Stopped or (Free_platforms > 0 and 
               (Request_Express'Count = 0 or Served_Not_Freight < Limit_Freight)) is
         begin
            platform_id := 0;
            if not Stopped then
               Assign_Platform(ID_Train, platform_id);
               Served_Not_Freight := Served_Not_Freight + 1;
            end if;
         end Request_Regional;

            entry Request_Freight(ID_Train : Integer; platform_id : out Integer) when Stopped or (Free_platforms > 0 
               and ((Request_Express'Count = 0 and Request_Regional'Count = 0) or Served_Not_Freight > 0)) is
         begin
            platform_id := 0;
            if not Stopped then
               Assign_Platform(ID_Train, platform_id);
               Served_Not_Freight := 0;
            end if;
         end Request_Freight;

         procedure Release(ID_Train : Integer; platform_id : out Integer) is
         begin 
            platform_id := Assigned_Platforms(ID_Train);
            if not Stopped and then platform_id > 0 then
               Platform_Free(platform_id) := True;
            end if;
            if not Stopped then
               Assigned_Platforms(ID_Train) := 0;
               Free_platforms := Free_platforms + 1;
            end if;
         end;
      end Platform_Type;
end platforms;