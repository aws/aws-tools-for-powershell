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
    /// Returns information about a stack drift detection operation. A stack drift detection
    /// operation detects whether a stack's actual configuration differs, or has <i>drifted</i>,
    /// from it's expected configuration, as defined in the stack template and any values
    /// specified as template parameters. A stack is considered to have drifted if one or
    /// more of its resources have drifted. For more information on stack and resource drift,
    /// see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-cfn-stack-drift.html">Detecting
    /// Unregulated Configuration Changes to Stacks and Resources</a>.
    /// 
    ///  
    /// <para>
    /// Use <a>DetectStackDrift</a> to initiate a stack drift detection operation. <code>DetectStackDrift</code>
    /// returns a <code>StackDriftDetectionId</code> you can use to monitor the progress of
    /// the operation using <code>DescribeStackDriftDetectionStatus</code>. Once the drift
    /// detection operation has completed, use <a>DescribeStackResourceDrifts</a> to return
    /// drift information about the stack and its resources.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFNStackDriftDetectionStatus")]
    [OutputType("Amazon.CloudFormation.Model.DescribeStackDriftDetectionStatusResponse")]
    [AWSCmdlet("Calls the AWS CloudFormation DescribeStackDriftDetectionStatus API operation.", Operation = new[] {"DescribeStackDriftDetectionStatus"})]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.DescribeStackDriftDetectionStatusResponse",
        "This cmdlet returns a Amazon.CloudFormation.Model.DescribeStackDriftDetectionStatusResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFNStackDriftDetectionStatusCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter StackDriftDetectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the drift detection results of this operation. </para><para>AWS CloudFormation generates new results, with a new drift detection ID, each time
        /// this operation is run. However, the number of drift results AWS CloudFormation retains
        /// for any given stack, and for how long, may vary. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StackDriftDetectionId { get; set; }
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
            
            context.StackDriftDetectionId = this.StackDriftDetectionId;
            
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
            var request = new Amazon.CloudFormation.Model.DescribeStackDriftDetectionStatusRequest();
            
            if (cmdletContext.StackDriftDetectionId != null)
            {
                request.StackDriftDetectionId = cmdletContext.StackDriftDetectionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.CloudFormation.Model.DescribeStackDriftDetectionStatusResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DescribeStackDriftDetectionStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DescribeStackDriftDetectionStatus");
            try
            {
                #if DESKTOP
                return client.DescribeStackDriftDetectionStatus(request);
                #elif CORECLR
                return client.DescribeStackDriftDetectionStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String StackDriftDetectionId { get; set; }
        }
        
    }
}
