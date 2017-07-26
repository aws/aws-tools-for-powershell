/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns the description of the specified stack set operation.
    /// </summary>
    [Cmdlet("Get", "CFNStackSetOperation")]
    [OutputType("Amazon.CloudFormation.Model.StackSetOperation")]
    [AWSCmdlet("Invokes the DescribeStackSetOperation operation against AWS CloudFormation.", Operation = new[] {"DescribeStackSetOperation"})]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.StackSetOperation",
        "This cmdlet returns a StackSetOperation object.",
        "The service call response (type Amazon.CloudFormation.Model.DescribeStackSetOperationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFNStackSetOperationCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter OperationId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the stack set operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String OperationId { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or the unique stack ID of the stack set for the stack operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StackSetName { get; set; }
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
            
            context.OperationId = this.OperationId;
            context.StackSetName = this.StackSetName;
            
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
            var request = new Amazon.CloudFormation.Model.DescribeStackSetOperationRequest();
            
            if (cmdletContext.OperationId != null)
            {
                request.OperationId = cmdletContext.OperationId;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StackSetOperation;
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
        
        private Amazon.CloudFormation.Model.DescribeStackSetOperationResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DescribeStackSetOperationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DescribeStackSetOperation");
            #if DESKTOP
            return client.DescribeStackSetOperation(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeStackSetOperationAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String OperationId { get; set; }
            public System.String StackSetName { get; set; }
        }
        
    }
}
