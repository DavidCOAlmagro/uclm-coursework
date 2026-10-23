with Monitor; use Monitor;
with config; use config;

package platforms is
   type Platform_Assignment_Array is array (index) of Natural;
   type Platform_Free_Array is array (Positive range <>) of Boolean;

   protected type Platform_Type(Number_platforms : Positive; Max_Trains : Positive; station_monitor : access Monitor_Type) is 
      procedure Stop;
      function Is_Stopped return Boolean;

      entry Request_Express(ID_Train : Integer; platform_id : out Integer);
      entry Request_Regional(ID_Train : Integer; platform_id : out Integer);
      entry Request_Freight(ID_Train : Integer; platform_id : out Integer);
      procedure Release(ID_Train : Integer; platform_id : out Integer);
      
      private
         Free_platforms : Natural := Number_platforms;
         Assigned_Platforms : Platform_Assignment_Array := (others => 0);
         Platform_Free : Platform_Free_Array(1 .. Number_platforms) := (others => True);
         Served_Not_Freight : Natural := 0;
         Limit_Freight : Integer := 3; -- Max number of trains which are not attended
         Stopped : Boolean := False;
         
         procedure Assign_Platform(ID_Train : Integer; platform_id : out Integer);
   end Platform_Type;

   procedure Request_Platform(p: in out Platform_Type; ID_Train : Integer; train_type : Train_T_Type);
   procedure Release_Platform(p: in out Platform_Type; ID_Train : Integer; train_type : Train_T_Type);

end platforms;