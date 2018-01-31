#pragma warning disable 612,618
#pragma warning disable 0114
#pragma warning disable 0108

using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
		public class LogEventRequest_SCORE_SUBMIT : GSTypedRequest<LogEventRequest_SCORE_SUBMIT, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_SCORE_SUBMIT() : base("LogEventRequest"){
			request.AddString("eventKey", "SCORE_SUBMIT");
		}
		public LogEventRequest_SCORE_SUBMIT Set_SCORE( long value )
		{
			request.AddNumber("SCORE", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_SCORE_SUBMIT : GSTypedRequest<LogChallengeEventRequest_SCORE_SUBMIT, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_SCORE_SUBMIT() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "SCORE_SUBMIT");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_SCORE_SUBMIT SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_SCORE_SUBMIT Set_SCORE( long value )
		{
			request.AddNumber("SCORE", value);
			return this;
		}			
	}
	
}
	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_HIGHSCORE : GSTypedRequest<LeaderboardDataRequest_HIGHSCORE,LeaderboardDataResponse_HIGHSCORE>
	{
		public LeaderboardDataRequest_HIGHSCORE() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "HIGHSCORE");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_HIGHSCORE (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_HIGHSCORE SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_HIGHSCORE SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_HIGHSCORE SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_HIGHSCORE SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_HIGHSCORE SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_HIGHSCORE SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_HIGHSCORE SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_HIGHSCORE SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_HIGHSCORE SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_HIGHSCORE : GSTypedRequest<AroundMeLeaderboardRequest_HIGHSCORE,AroundMeLeaderboardResponse_HIGHSCORE>
	{
		public AroundMeLeaderboardRequest_HIGHSCORE() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "HIGHSCORE");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_HIGHSCORE (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_HIGHSCORE SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_HIGHSCORE SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_HIGHSCORE SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_HIGHSCORE SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_HIGHSCORE SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_HIGHSCORE SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_HIGHSCORE SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_HIGHSCORE : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_HIGHSCORE(GSData data) : base(data){}
		public long? SCORE{
			get{return response.GetNumber("SCORE");}
		}
	}
	
	public class LeaderboardDataResponse_HIGHSCORE : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_HIGHSCORE(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_HIGHSCORE> Data_HIGHSCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGHSCORE>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_HIGHSCORE(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HIGHSCORE> First_HIGHSCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGHSCORE>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_HIGHSCORE(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HIGHSCORE> Last_HIGHSCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGHSCORE>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_HIGHSCORE(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_HIGHSCORE : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_HIGHSCORE(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_HIGHSCORE> Data_HIGHSCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGHSCORE>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_HIGHSCORE(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HIGHSCORE> First_HIGHSCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGHSCORE>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_HIGHSCORE(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HIGHSCORE> Last_HIGHSCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGHSCORE>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_HIGHSCORE(data);});}
		}
	}
}	

namespace GameSparks.Api.Messages {


}
