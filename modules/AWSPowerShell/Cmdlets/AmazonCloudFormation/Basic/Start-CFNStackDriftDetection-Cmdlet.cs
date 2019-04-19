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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Detects whether a stack's actual configuration differs, or has <i>drifted</i>, from
    /// it's expected configuration, as defined in the stack template and any values specified
    /// as template parameters. For each resource in the stack that supports drift detection,
    /// AWS CloudFormation compares the actual configuration of the resource with its expected
    /// template configuration. Only resource properties explicitly defined in the stack template
    /// are checked for drift. A stack is considered to have drifted if one or more of its
    /// resources differ from their expected template configurations. For more information,
    /// see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-cfn-stack-drift.html">Detecting
    /// Unregulated Configuration Changes to Stacks and Resources</a>.
    /// 
    ///  
    /// <para>
    /// Use <code>DetectStackDrift</code> to detect drift on all supported resources for a
    /// given stack, or <a>DetectStackResourceDrift</a> to detect drift on individual resources.
    /// </para><para>
    /// For a list of stack resources that currently support drift detection, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-cfn-stack-drift-resource-list.html">Resources
    /// that Support Drift Detection</a>.
    /// </para><para><code>DetectStackDrift</code> can take up to several minutes, depending on the number
    /// of resources contained within the stack. Use <a>DescribeStackDriftDetectionStatus</a>
    /// to monitor the progress of a detect stack drift operation. Once the drift detection
    /// operation has completed, use <a>DescribeStackResourceDrifts</a> to return drift information
    /// about the stack and its resources.
    /// </para><para>
    /// When detecting drift on a stack, AWS CloudFormation does not detect drift on any nested
    /// stacks belonging to that stack. Perform <code>DetectStackDrift</code> directly on
    /// the nested stack itself.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CFNStackDriftDetection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation DetectStackDrift API operation.", Operation = new[] {"DetectStackDrift"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudFormation.Model.DetectStackDriftResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCFNStackDriftDetectionCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter LogicalResourceId
        /// <summary>
        /// <para>
        /// <para>The logical names of any resources you want to use as filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogicalResourceIds")]
        public System.String[] LogicalResourceId { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name of the stack for which you want to detect drift. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CFNStackDriftDetection (DetectStackDrift)"))
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
            
            if (this.LogicalResourceId != null)
            {
                context.LogicalResourceIds = new List<System.String>(this.LogicalResourceId);
            }
            context.StackName = this.StackName;
            
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
            var request = new Amazon.CloudFormation.Model.DetectStackDriftRequest();
            
            if (cmdletContext.LogicalResourceIds != null)
            {
                request.LogicalResourceIds = cmdletContext.LogicalResourceIds;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StackDriftDetectionId;
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
        
        private Amazon.CloudFormation.Model.DetectStackDriftResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DetectStackDriftRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DetectStackDrift");
            try
            {
                #if DESKTOP
                return client.DetectStackDrift(request);
                #elif CORECLR
                return client.DetectStackDriftAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> LogicalResourceIds { get; set; }
            public System.String StackName { get; set; }
        }
        
    }
}
