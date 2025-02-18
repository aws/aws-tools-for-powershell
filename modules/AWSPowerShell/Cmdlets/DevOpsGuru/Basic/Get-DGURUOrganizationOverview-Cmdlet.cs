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
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Returns an overview of your organization's history based on the specified time range.
    /// The overview includes the total reactive and proactive insights.
    /// </summary>
    [Cmdlet("Get", "DGURUOrganizationOverview")]
    [OutputType("Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewResponse")]
    [AWSCmdlet("Calls the Amazon DevOps Guru DescribeOrganizationOverview API operation.", Operation = new[] {"DescribeOrganizationOverview"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewResponse))]
    [AWSCmdletOutput("Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewResponse",
        "This cmdlet returns an Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewResponse object containing multiple properties."
    )]
    public partial class GetDGURUOrganizationOverviewCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter FromTime
        /// <summary>
        /// <para>
        /// <para> The start of the time range passed in. The start time granularity is at the day level.
        /// The floor of the start time is used. Returned information occurred after this day.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? FromTime { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The ID of the organizational unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OrganizationalUnitIds")]
        public System.String[] OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter ToTime
        /// <summary>
        /// <para>
        /// <para> The end of the time range passed in. The start time granularity is at the day level.
        /// The floor of the start time is used. Returned information occurred before this day.
        /// If this is not specified, then the current day is used. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ToTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewResponse).
        /// Specifying the name of a property of type Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewResponse, GetDGURUOrganizationOverviewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            context.FromTime = this.FromTime;
            #if MODULAR
            if (this.FromTime == null && ParameterWasBound(nameof(this.FromTime)))
            {
                WriteWarning("You are passing $null as a value for parameter FromTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OrganizationalUnitId != null)
            {
                context.OrganizationalUnitId = new List<System.String>(this.OrganizationalUnitId);
            }
            context.ToTime = this.ToTime;
            
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
            var request = new Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            if (cmdletContext.FromTime != null)
            {
                request.FromTime = cmdletContext.FromTime.Value;
            }
            if (cmdletContext.OrganizationalUnitId != null)
            {
                request.OrganizationalUnitIds = cmdletContext.OrganizationalUnitId;
            }
            if (cmdletContext.ToTime != null)
            {
                request.ToTime = cmdletContext.ToTime.Value;
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
        
        private Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "DescribeOrganizationOverview");
            try
            {
                return client.DescribeOrganizationOverviewAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public System.DateTime? FromTime { get; set; }
            public List<System.String> OrganizationalUnitId { get; set; }
            public System.DateTime? ToTime { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.DescribeOrganizationOverviewResponse, GetDGURUOrganizationOverviewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
