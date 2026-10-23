with Monitor; use Monitor;
with config;  use config;

package single_tracks is
   type Single_Track (station_monitor : Monitor_Access) is limited private;

   procedure Stop (T : in out Single_Track);
   function Is_Stopped (T : Single_Track) return Boolean;

   procedure Request_Track
     (T : in out Single_Track; ID_Train : Integer; train_type : Train_T_Type; 
     dir : Direction);
   procedure Release_Track
     (T : in out Single_Track; ID_Train : Integer; train_type : Train_T_Type;
      dir : Direction);

private
   type track_state_kind is (Free, Busy);

   protected type Single_Track (station_monitor : Monitor_Access) is
      procedure Stop;
      function Is_Stopped return Boolean;

      entry Request_Entry;
      entry Request_Exit;
      procedure Release;

   private
      Current_State : track_state_kind := Free;
      Last_Served   : Direction := Leaving;
      Stopped       : Boolean := False;
   end Single_Track;
end single_tracks;
