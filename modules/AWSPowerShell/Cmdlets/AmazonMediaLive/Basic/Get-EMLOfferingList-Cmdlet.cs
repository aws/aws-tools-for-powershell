/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// List offerings available for purchase.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "EMLOfferingList")]
    [OutputType("Amazon.MediaLive.Model.Offering")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive ListOfferings API operation.", Operation = new[] {"ListOfferings"})]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Offering",
        "This cmdlet returns a collection of Offering objects.",
        "The service call response (type Amazon.MediaLive.Model.ListOfferingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetEMLOfferingListCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        #region Parameter ChannelConfiguration
        /// <summary>
        /// <para>
        /// Filter to offerings that match the
        /// configuration of an existing channel, e.g. '2345678' (a channel ID)
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChannelConfiguration { get; set; }
        #endregion
        
        #region Parameter Codec
        /// <summary>
        /// <para>
        /// Filter by codec, 'AVC', 'HEVC', 'MPEG2', or 'AUDIO'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Codec { get; set; }
        #endregion
        
        #region Parameter MaximumBitrate
        /// <summary>
        /// <para>
        /// Filter by bitrate, 'MAX_10_MBPS', 'MAX_20_MBPS',
        /// or 'MAX_50_MBPS'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MaximumBitrate { get; set; }
        #endregion
        
        #region Parameter MaximumFramerate
        /// <summary>
        /// <para>
        /// Filter by framerate, 'MAX_30_FPS' or
        /// 'MAX_60_FPS'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MaximumFramerate { get; set; }
        #endregion
        
        #region Parameter Resolution
        /// <summary>
        /// <para>
        /// Filter by resolution, 'SD', 'HD', or 'UHD'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Resolution { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// Filter by resource type, 'INPUT', 'OUTPUT',
        /// or 'CHANNEL'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter SpecialFeature
        /// <summary>
        /// <para>
        /// Filter by special feature, 'ADVANCED_AUDIO'
        /// or 'AUDIO_NORMALIZATION'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SpecialFeature { get; set; }
        #endregion
        
        #region Parameter VideoQuality
        /// <summary>
        /// <para>
        /// Filter by video quality, 'STANDARD', 'ENHANCED',
        /// or 'PREMIUM'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VideoQuality { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ChannelConfiguration = this.ChannelConfiguration;
            context.Codec = this.Codec;
            context.MaximumBitrate = this.MaximumBitrate;
            context.MaximumFramerate = this.MaximumFramerate;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Resolution = this.Resolution;
            context.ResourceType = this.ResourceType;
            context.SpecialFeature = this.SpecialFeature;
            context.VideoQuality = this.VideoQuality;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.MediaLive.Model.ListOfferingsRequest();
            if (cmdletContext.ChannelConfiguration != null)
            {
                request.ChannelConfiguration = cmdletContext.ChannelConfiguration;
            }
            if (cmdletContext.Codec != null)
            {
                request.Codec = cmdletContext.Codec;
            }
            if (cmdletContext.MaximumBitrate != null)
            {
                request.MaximumBitrate = cmdletContext.MaximumBitrate;
            }
            if (cmdletContext.MaximumFramerate != null)
            {
                request.MaximumFramerate = cmdletContext.MaximumFramerate;
            }
            if (cmdletContext.Resolution != null)
            {
                request.Resolution = cmdletContext.Resolution;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.SpecialFeature != null)
            {
                request.SpecialFeature = cmdletContext.SpecialFeature;
            }
            if (cmdletContext.VideoQuality != null)
            {
                request.VideoQuality = cmdletContext.VideoQuality;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken") || ParameterWasBound("MaxResult");
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Offerings;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Offerings.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MediaLive.Model.ListOfferingsResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.ListOfferingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "ListOfferings");
            try
            {
                #if DESKTOP
                return client.ListOfferings(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListOfferingsAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ChannelConfiguration { get; set; }
            public System.String Codec { get; set; }
            public System.String MaximumBitrate { get; set; }
            public System.String MaximumFramerate { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String Resolution { get; set; }
            public System.String ResourceType { get; set; }
            public System.String SpecialFeature { get; set; }
            public System.String VideoQuality { get; set; }
        }
        
    }
}
