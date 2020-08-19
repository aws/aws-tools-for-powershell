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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Modifies the feedback property of a given cost anomaly.
    /// </summary>
    [Cmdlet("Set", "CEAnomalyFeedback", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Cost Explorer ProvideAnomalyFeedback API operation.", Operation = new[] {"ProvideAnomalyFeedback"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.ProvideAnomalyFeedbackResponse))]
    [AWSCmdletOutput("System.String or Amazon.CostExplorer.Model.ProvideAnomalyFeedbackResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CostExplorer.Model.ProvideAnomalyFeedbackResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetCEAnomalyFeedbackCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter AnomalyId
        /// <summary>
        /// <para>
        /// <para> A cost anomaly ID. </para>
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
        public System.String AnomalyId { get; set; }
        #endregion
        
        #region Parameter Feedback
        /// <summary>
        /// <para>
        /// <para>Describes whether the cost anomaly was a planned activity or you considered it an
        /// anomaly. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.AnomalyFeedbackType")]
        public Amazon.CostExplorer.AnomalyFeedbackType Feedback { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnomalyId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.ProvideAnomalyFeedbackResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.ProvideAnomalyFeedbackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnomalyId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AnomalyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CEAnomalyFeedback (ProvideAnomalyFeedback)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.ProvideAnomalyFeedbackResponse, SetCEAnomalyFeedbackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyId = this.AnomalyId;
            #if MODULAR
            if (this.AnomalyId == null && ParameterWasBound(nameof(this.AnomalyId)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Feedback = this.Feedback;
            #if MODULAR
            if (this.Feedback == null && ParameterWasBound(nameof(this.Feedback)))
            {
                WriteWarning("You are passing $null as a value for parameter Feedback which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CostExplorer.Model.ProvideAnomalyFeedbackRequest();
            
            if (cmdletContext.AnomalyId != null)
            {
                request.AnomalyId = cmdletContext.AnomalyId;
            }
            if (cmdletContext.Feedback != null)
            {
                request.Feedback = cmdletContext.Feedback;
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
        
        private Amazon.CostExplorer.Model.ProvideAnomalyFeedbackResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.ProvideAnomalyFeedbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "ProvideAnomalyFeedback");
            try
            {
                #if DESKTOP
                return client.ProvideAnomalyFeedback(request);
                #elif CORECLR
                return client.ProvideAnomalyFeedbackAsync(request).GetAwaiter().GetResult();
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
            public System.String AnomalyId { get; set; }
            public Amazon.CostExplorer.AnomalyFeedbackType Feedback { get; set; }
            public System.Func<Amazon.CostExplorer.Model.ProvideAnomalyFeedbackResponse, SetCEAnomalyFeedbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnomalyId;
        }
        
    }
}
