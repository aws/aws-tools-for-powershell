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
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Creates a new assessment target using the ARN of the resource group that is generated
    /// by <a>CreateResourceGroup</a>. If resourceGroupArn is not specified, all EC2 instances
    /// in the current AWS account and region are included in the assessment target. If the
    /// <a href="https://docs.aws.amazon.com/inspector/latest/userguide/inspector_slr.html">service-linked
    /// role</a> isn’t already registered, this action also creates and registers a service-linked
    /// role to grant Amazon Inspector access to AWS Services needed to perform security assessments.
    /// You can create up to 50 assessment targets per AWS account. You can run up to 500
    /// concurrent agents per AWS account. For more information, see <a href="http://docs.aws.amazon.com/inspector/latest/userguide/inspector_applications.html">
    /// Amazon Inspector Assessment Targets</a>.
    /// </summary>
    [Cmdlet("New", "INSAssessmentTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Inspector CreateAssessmentTarget API operation.", Operation = new[] {"CreateAssessmentTarget"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Inspector.Model.CreateAssessmentTargetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewINSAssessmentTargetCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter AssessmentTargetName
        /// <summary>
        /// <para>
        /// <para>The user-defined name that identifies the assessment target that you want to create.
        /// The name must be unique within the AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssessmentTargetName { get; set; }
        #endregion
        
        #region Parameter ResourceGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN that specifies the resource group that is used to create the assessment target.
        /// If resourceGroupArn is not specified, all EC2 instances in the current AWS account
        /// and region are included in the assessment target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AssessmentTargetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-INSAssessmentTarget (CreateAssessmentTarget)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AssessmentTargetName = this.AssessmentTargetName;
            context.ResourceGroupArn = this.ResourceGroupArn;
            
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
            var request = new Amazon.Inspector.Model.CreateAssessmentTargetRequest();
            
            if (cmdletContext.AssessmentTargetName != null)
            {
                request.AssessmentTargetName = cmdletContext.AssessmentTargetName;
            }
            if (cmdletContext.ResourceGroupArn != null)
            {
                request.ResourceGroupArn = cmdletContext.ResourceGroupArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AssessmentTargetArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Inspector.Model.CreateAssessmentTargetResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.CreateAssessmentTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "CreateAssessmentTarget");
            try
            {
                #if DESKTOP
                return client.CreateAssessmentTarget(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateAssessmentTargetAsync(request);
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
            public System.String AssessmentTargetName { get; set; }
            public System.String ResourceGroupArn { get; set; }
        }
        
    }
}
