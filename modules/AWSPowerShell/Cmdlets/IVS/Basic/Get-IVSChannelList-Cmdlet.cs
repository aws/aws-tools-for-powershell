/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.IVS;
using Amazon.IVS.Model;

namespace Amazon.PowerShell.Cmdlets.IVS
{
    /// <summary>
    /// Gets summary information about all channels in your account, in the Amazon Web Services
    /// region where the API request is processed. This list can be filtered to match a specified
    /// name or recording-configuration ARN. Filters are mutually exclusive and cannot be
    /// used together. If you try to use both filters, you will get an error (409 ConflictException).
    /// </summary>
    [Cmdlet("Get", "IVSChannelList")]
    [OutputType("Amazon.IVS.Model.ChannelSummary")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service ListChannels API operation.", Operation = new[] {"ListChannels"}, SelectReturnType = typeof(Amazon.IVS.Model.ListChannelsResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.ChannelSummary or Amazon.IVS.Model.ListChannelsResponse",
        "This cmdlet returns a collection of Amazon.IVS.Model.ChannelSummary objects.",
        "The service call response (type Amazon.IVS.Model.ListChannelsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIVSChannelListCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FilterByName
        /// <summary>
        /// <para>
        /// <para>Filters the channel list to match the specified name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FilterByName { get; set; }
        #endregion
        
        #region Parameter FilterByPlaybackRestrictionPolicyArn
        /// <summary>
        /// <para>
        /// <para>Filters the channel list to match the specified policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterByPlaybackRestrictionPolicyArn { get; set; }
        #endregion
        
        #region Parameter FilterByRecordingConfigurationArn
        /// <summary>
        /// <para>
        /// <para>Filters the channel list to match the specified recording-configuration ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterByRecordingConfigurationArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of channels to return. Default: 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The first channel to retrieve. This is used for pagination; see the <c>nextToken</c>
        /// response field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Channels'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.ListChannelsResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.ListChannelsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Channels";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.ListChannelsResponse, GetIVSChannelListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FilterByName = this.FilterByName;
            context.FilterByPlaybackRestrictionPolicyArn = this.FilterByPlaybackRestrictionPolicyArn;
            context.FilterByRecordingConfigurationArn = this.FilterByRecordingConfigurationArn;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IVS.Model.ListChannelsRequest();
            
            if (cmdletContext.FilterByName != null)
            {
                request.FilterByName = cmdletContext.FilterByName;
            }
            if (cmdletContext.FilterByPlaybackRestrictionPolicyArn != null)
            {
                request.FilterByPlaybackRestrictionPolicyArn = cmdletContext.FilterByPlaybackRestrictionPolicyArn;
            }
            if (cmdletContext.FilterByRecordingConfigurationArn != null)
            {
                request.FilterByRecordingConfigurationArn = cmdletContext.FilterByRecordingConfigurationArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IVS.Model.ListChannelsResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.ListChannelsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "ListChannels");
            try
            {
                #if DESKTOP
                return client.ListChannels(request);
                #elif CORECLR
                return client.ListChannelsAsync(request).GetAwaiter().GetResult();
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
            public System.String FilterByName { get; set; }
            public System.String FilterByPlaybackRestrictionPolicyArn { get; set; }
            public System.String FilterByRecordingConfigurationArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.IVS.Model.ListChannelsResponse, GetIVSChannelListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Channels;
        }
        
    }
}
