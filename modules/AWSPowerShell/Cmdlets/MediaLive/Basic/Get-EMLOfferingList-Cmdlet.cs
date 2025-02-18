/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// List offerings available for purchase.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EMLOfferingList")]
    [OutputType("Amazon.MediaLive.Model.Offering")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive ListOfferings API operation.", Operation = new[] {"ListOfferings"}, SelectReturnType = typeof(Amazon.MediaLive.Model.ListOfferingsResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Offering or Amazon.MediaLive.Model.ListOfferingsResponse",
        "This cmdlet returns a collection of Amazon.MediaLive.Model.Offering objects.",
        "The service call response (type Amazon.MediaLive.Model.ListOfferingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEMLOfferingListCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChannelClass
        /// <summary>
        /// <para>
        /// Filter by channel class, 'STANDARD' or 'SINGLE_PIPELINE'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelClass { get; set; }
        #endregion
        
        #region Parameter ChannelConfiguration
        /// <summary>
        /// <para>
        /// Filter to offerings that match the
        /// configuration of an existing channel, e.g. '2345678' (a channel ID)
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelConfiguration { get; set; }
        #endregion
        
        #region Parameter Codec
        /// <summary>
        /// <para>
        /// Filter by codec, 'AVC', 'HEVC', 'MPEG2', 'AUDIO',
        /// 'LINK', or 'AV1'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Codec { get; set; }
        #endregion
        
        #region Parameter Duration
        /// <summary>
        /// <para>
        /// Filter by offering duration, e.g. '12'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Duration { get; set; }
        #endregion
        
        #region Parameter MaximumBitrate
        /// <summary>
        /// <para>
        /// Filter by bitrate, 'MAX_10_MBPS', 'MAX_20_MBPS',
        /// or 'MAX_50_MBPS'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaximumBitrate { get; set; }
        #endregion
        
        #region Parameter MaximumFramerate
        /// <summary>
        /// <para>
        /// Filter by framerate, 'MAX_30_FPS' or
        /// 'MAX_60_FPS'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaximumFramerate { get; set; }
        #endregion
        
        #region Parameter Resolution
        /// <summary>
        /// <para>
        /// Filter by resolution, 'SD', 'HD', 'FHD', or
        /// 'UHD'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resolution { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// Filter by resource type, 'INPUT', 'OUTPUT',
        /// 'MULTIPLEX', or 'CHANNEL'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter SpecialFeature
        /// <summary>
        /// <para>
        /// Filter by special feature, 'ADVANCED_AUDIO'
        /// or 'AUDIO_NORMALIZATION'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SpecialFeature { get; set; }
        #endregion
        
        #region Parameter VideoQuality
        /// <summary>
        /// <para>
        /// Filter by video quality, 'STANDARD', 'ENHANCED',
        /// or 'PREMIUM'
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VideoQuality { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Offerings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.ListOfferingsResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.ListOfferingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Offerings";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.ListOfferingsResponse, GetEMLOfferingListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelClass = this.ChannelClass;
            context.ChannelConfiguration = this.ChannelConfiguration;
            context.Codec = this.Codec;
            context.Duration = this.Duration;
            context.MaximumBitrate = this.MaximumBitrate;
            context.MaximumFramerate = this.MaximumFramerate;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
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
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.MediaLive.Model.ListOfferingsRequest();
            
            if (cmdletContext.ChannelClass != null)
            {
                request.ChannelClass = cmdletContext.ChannelClass;
            }
            if (cmdletContext.ChannelConfiguration != null)
            {
                request.ChannelConfiguration = cmdletContext.ChannelConfiguration;
            }
            if (cmdletContext.Codec != null)
            {
                request.Codec = cmdletContext.Codec;
            }
            if (cmdletContext.Duration != null)
            {
                request.Duration = cmdletContext.Duration;
            }
            if (cmdletContext.MaximumBitrate != null)
            {
                request.MaximumBitrate = cmdletContext.MaximumBitrate;
            }
            if (cmdletContext.MaximumFramerate != null)
            {
                request.MaximumFramerate = cmdletContext.MaximumFramerate;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.MediaLive.Model.ListOfferingsRequest();
            if (cmdletContext.ChannelClass != null)
            {
                request.ChannelClass = cmdletContext.ChannelClass;
            }
            if (cmdletContext.ChannelConfiguration != null)
            {
                request.ChannelConfiguration = cmdletContext.ChannelConfiguration;
            }
            if (cmdletContext.Codec != null)
            {
                request.Codec = cmdletContext.Codec;
            }
            if (cmdletContext.Duration != null)
            {
                request.Duration = cmdletContext.Duration;
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
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    int _receivedThisCall = response.Offerings?.Count ?? 0;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
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
                return client.ListOfferingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChannelClass { get; set; }
            public System.String ChannelConfiguration { get; set; }
            public System.String Codec { get; set; }
            public System.String Duration { get; set; }
            public System.String MaximumBitrate { get; set; }
            public System.String MaximumFramerate { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Resolution { get; set; }
            public System.String ResourceType { get; set; }
            public System.String SpecialFeature { get; set; }
            public System.String VideoQuality { get; set; }
            public System.Func<Amazon.MediaLive.Model.ListOfferingsResponse, GetEMLOfferingListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Offerings;
        }
        
    }
}
