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
using Amazon.MediaPackageV2;
using Amazon.MediaPackageV2.Model;

namespace Amazon.PowerShell.Cmdlets.MPV2
{
    /// <summary>
    /// Retrieves a list of harvest jobs that match the specified criteria.
    /// </summary>
    [Cmdlet("Get", "MPV2HarvestJobList")]
    [OutputType("Amazon.MediaPackageV2.Model.HarvestJob")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage v2 ListHarvestJobs API operation.", Operation = new[] {"ListHarvestJobs"}, SelectReturnType = typeof(Amazon.MediaPackageV2.Model.ListHarvestJobsResponse))]
    [AWSCmdletOutput("Amazon.MediaPackageV2.Model.HarvestJob or Amazon.MediaPackageV2.Model.ListHarvestJobsResponse",
        "This cmdlet returns a collection of Amazon.MediaPackageV2.Model.HarvestJob objects.",
        "The service call response (type Amazon.MediaPackageV2.Model.ListHarvestJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMPV2HarvestJobListCmdlet : AmazonMediaPackageV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the channel group to filter the harvest jobs by. If specified, only harvest
        /// jobs associated with channels in this group will be returned.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ChannelGroupName { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the channel to filter the harvest jobs by. If specified, only harvest
        /// jobs associated with this channel will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter OriginEndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the origin endpoint to filter the harvest jobs by. If specified, only
        /// harvest jobs associated with this origin endpoint will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OriginEndpointName { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status to filter the harvest jobs by. If specified, only harvest jobs with this
        /// status will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaPackageV2.HarvestJobStatus")]
        public Amazon.MediaPackageV2.HarvestJobStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of harvest jobs to return in a single request. If not specified,
        /// a default value will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token used for pagination. Provide this value in subsequent requests to retrieve
        /// the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaPackageV2.Model.ListHarvestJobsResponse).
        /// Specifying the name of a property of type Amazon.MediaPackageV2.Model.ListHarvestJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChannelGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChannelGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChannelGroupName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaPackageV2.Model.ListHarvestJobsResponse, GetMPV2HarvestJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChannelGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChannelGroupName = this.ChannelGroupName;
            #if MODULAR
            if (this.ChannelGroupName == null && ParameterWasBound(nameof(this.ChannelGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelName = this.ChannelName;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OriginEndpointName = this.OriginEndpointName;
            context.Status = this.Status;
            
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
            var request = new Amazon.MediaPackageV2.Model.ListHarvestJobsRequest();
            
            if (cmdletContext.ChannelGroupName != null)
            {
                request.ChannelGroupName = cmdletContext.ChannelGroupName;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.OriginEndpointName != null)
            {
                request.OriginEndpointName = cmdletContext.OriginEndpointName;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.MediaPackageV2.Model.ListHarvestJobsResponse CallAWSServiceOperation(IAmazonMediaPackageV2 client, Amazon.MediaPackageV2.Model.ListHarvestJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage v2", "ListHarvestJobs");
            try
            {
                #if DESKTOP
                return client.ListHarvestJobs(request);
                #elif CORECLR
                return client.ListHarvestJobsAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelGroupName { get; set; }
            public System.String ChannelName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OriginEndpointName { get; set; }
            public Amazon.MediaPackageV2.HarvestJobStatus Status { get; set; }
            public System.Func<Amazon.MediaPackageV2.Model.ListHarvestJobsResponse, GetMPV2HarvestJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
