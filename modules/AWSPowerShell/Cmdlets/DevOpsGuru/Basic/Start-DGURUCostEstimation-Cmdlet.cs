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
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Starts the creation of an estimate of the monthly cost to analyze your Amazon Web
    /// Services resources.
    /// </summary>
    [Cmdlet("Start", "DGURUCostEstimation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon DevOps Guru StartCostEstimation API operation.", Operation = new[] {"StartCostEstimation"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.StartCostEstimationResponse))]
    [AWSCmdletOutput("None or Amazon.DevOpsGuru.Model.StartCostEstimationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DevOpsGuru.Model.StartCostEstimationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartDGURUCostEstimationCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        #region Parameter CloudFormation_StackName
        /// <summary>
        /// <para>
        /// <para>An array of CloudFormation stack names. Its size is fixed at 1 item.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceCollection_CloudFormation_StackNames")]
        public System.String[] CloudFormation_StackName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token used to identify each cost estimate request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.StartCostEstimationResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DGURUCostEstimation (StartCostEstimation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.StartCostEstimationResponse, StartDGURUCostEstimationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.CloudFormation_StackName != null)
            {
                context.CloudFormation_StackName = new List<System.String>(this.CloudFormation_StackName);
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
            var request = new Amazon.DevOpsGuru.Model.StartCostEstimationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ResourceCollection
            var requestResourceCollectionIsNull = true;
            request.ResourceCollection = new Amazon.DevOpsGuru.Model.CostEstimationResourceCollectionFilter();
            Amazon.DevOpsGuru.Model.CloudFormationCostEstimationResourceCollectionFilter requestResourceCollection_resourceCollection_CloudFormation = null;
            
             // populate CloudFormation
            var requestResourceCollection_resourceCollection_CloudFormationIsNull = true;
            requestResourceCollection_resourceCollection_CloudFormation = new Amazon.DevOpsGuru.Model.CloudFormationCostEstimationResourceCollectionFilter();
            List<System.String> requestResourceCollection_resourceCollection_CloudFormation_cloudFormation_StackName = null;
            if (cmdletContext.CloudFormation_StackName != null)
            {
                requestResourceCollection_resourceCollection_CloudFormation_cloudFormation_StackName = cmdletContext.CloudFormation_StackName;
            }
            if (requestResourceCollection_resourceCollection_CloudFormation_cloudFormation_StackName != null)
            {
                requestResourceCollection_resourceCollection_CloudFormation.StackNames = requestResourceCollection_resourceCollection_CloudFormation_cloudFormation_StackName;
                requestResourceCollection_resourceCollection_CloudFormationIsNull = false;
            }
             // determine if requestResourceCollection_resourceCollection_CloudFormation should be set to null
            if (requestResourceCollection_resourceCollection_CloudFormationIsNull)
            {
                requestResourceCollection_resourceCollection_CloudFormation = null;
            }
            if (requestResourceCollection_resourceCollection_CloudFormation != null)
            {
                request.ResourceCollection.CloudFormation = requestResourceCollection_resourceCollection_CloudFormation;
                requestResourceCollectionIsNull = false;
            }
             // determine if request.ResourceCollection should be set to null
            if (requestResourceCollectionIsNull)
            {
                request.ResourceCollection = null;
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
        
        private Amazon.DevOpsGuru.Model.StartCostEstimationResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.StartCostEstimationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "StartCostEstimation");
            try
            {
                #if DESKTOP
                return client.StartCostEstimation(request);
                #elif CORECLR
                return client.StartCostEstimationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<System.String> CloudFormation_StackName { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.StartCostEstimationResponse, StartDGURUCostEstimationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
