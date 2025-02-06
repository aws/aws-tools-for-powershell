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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// <note><para>
    /// The <i>aggregation Region</i> is now called the <i>home Region</i>.
    /// </para></note><para>
    /// Updates cross-Region aggregation settings. You can use this operation to update the
    /// Region linking mode and the list of included or excluded Amazon Web Services Regions.
    /// However, you can't use this operation to change the home Region.
    /// </para><para>
    /// You can invoke this operation from the current home Region only. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SHUBFindingAggregator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.UpdateFindingAggregatorResponse")]
    [AWSCmdlet("Calls the AWS Security Hub UpdateFindingAggregator API operation.", Operation = new[] {"UpdateFindingAggregator"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.UpdateFindingAggregatorResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.UpdateFindingAggregatorResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.UpdateFindingAggregatorResponse object containing multiple properties."
    )]
    public partial class UpdateSHUBFindingAggregatorCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FindingAggregatorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the finding aggregator. To obtain the ARN, use <c>ListFindingAggregators</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FindingAggregatorArn { get; set; }
        #endregion
        
        #region Parameter RegionLinkingMode
        /// <summary>
        /// <para>
        /// <para>Indicates whether to aggregate findings from all of the available Regions in the current
        /// partition. Also determines whether to automatically aggregate findings from new Regions
        /// as Security Hub supports them and you opt into them.</para><para>The selected option also determines how to use the Regions provided in the Regions
        /// list.</para><para>The options are as follows:</para><ul><li><para><c>ALL_REGIONS</c> - Aggregates findings from all of the Regions where Security Hub
        /// is enabled. When you choose this option, Security Hub also automatically aggregates
        /// findings from new Regions as Security Hub supports them and you opt into them. </para></li><li><para><c>ALL_REGIONS_EXCEPT_SPECIFIED</c> - Aggregates findings from all of the Regions
        /// where Security Hub is enabled, except for the Regions listed in the <c>Regions</c>
        /// parameter. When you choose this option, Security Hub also automatically aggregates
        /// findings from new Regions as Security Hub supports them and you opt into them. </para></li><li><para><c>SPECIFIED_REGIONS</c> - Aggregates findings only from the Regions listed in the
        /// <c>Regions</c> parameter. Security Hub does not automatically aggregate findings from
        /// new Regions. </para></li><li><para><c>NO_REGIONS</c> - Aggregates no data because no Regions are selected as linked
        /// Regions. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RegionLinkingMode { get; set; }
        #endregion
        
        #region Parameter RegionList
        /// <summary>
        /// <para>
        /// <para>If <c>RegionLinkingMode</c> is <c>ALL_REGIONS_EXCEPT_SPECIFIED</c>, then this is a
        /// space-separated list of Regions that don't replicate and send findings to the home
        /// Region.</para><para>If <c>RegionLinkingMode</c> is <c>SPECIFIED_REGIONS</c>, then this is a space-separated
        /// list of Regions that do replicate and send findings to the home Region.</para><para>An <c>InvalidInputException</c> error results if you populate this field while <c>RegionLinkingMode</c>
        /// is <c>NO_REGIONS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Regions")]
        public System.String[] RegionList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.UpdateFindingAggregatorResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.UpdateFindingAggregatorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FindingAggregatorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHUBFindingAggregator (UpdateFindingAggregator)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.UpdateFindingAggregatorResponse, UpdateSHUBFindingAggregatorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FindingAggregatorArn = this.FindingAggregatorArn;
            #if MODULAR
            if (this.FindingAggregatorArn == null && ParameterWasBound(nameof(this.FindingAggregatorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingAggregatorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegionLinkingMode = this.RegionLinkingMode;
            #if MODULAR
            if (this.RegionLinkingMode == null && ParameterWasBound(nameof(this.RegionLinkingMode)))
            {
                WriteWarning("You are passing $null as a value for parameter RegionLinkingMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RegionList != null)
            {
                context.RegionList = new List<System.String>(this.RegionList);
            }
            
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
            var request = new Amazon.SecurityHub.Model.UpdateFindingAggregatorRequest();
            
            if (cmdletContext.FindingAggregatorArn != null)
            {
                request.FindingAggregatorArn = cmdletContext.FindingAggregatorArn;
            }
            if (cmdletContext.RegionLinkingMode != null)
            {
                request.RegionLinkingMode = cmdletContext.RegionLinkingMode;
            }
            if (cmdletContext.RegionList != null)
            {
                request.Regions = cmdletContext.RegionList;
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
        
        private Amazon.SecurityHub.Model.UpdateFindingAggregatorResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.UpdateFindingAggregatorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "UpdateFindingAggregator");
            try
            {
                #if DESKTOP
                return client.UpdateFindingAggregator(request);
                #elif CORECLR
                return client.UpdateFindingAggregatorAsync(request).GetAwaiter().GetResult();
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
            public System.String FindingAggregatorArn { get; set; }
            public System.String RegionLinkingMode { get; set; }
            public List<System.String> RegionList { get; set; }
            public System.Func<Amazon.SecurityHub.Model.UpdateFindingAggregatorResponse, UpdateSHUBFindingAggregatorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
