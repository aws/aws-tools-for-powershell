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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Describes the lifecycle hooks for the specified Auto Scaling group.
    /// </summary>
    [Cmdlet("Get", "ASLifecycleHook")]
    [OutputType("Amazon.AutoScaling.Model.LifecycleHook")]
    [AWSCmdlet("Calls the Auto Scaling DescribeLifecycleHooks API operation.", Operation = new[] {"DescribeLifecycleHooks"}, LegacyAlias="Get-ASLifecycleHooks")]
    [AWSCmdletOutput("Amazon.AutoScaling.Model.LifecycleHook",
        "This cmdlet returns a collection of LifecycleHook objects.",
        "The service call response (type Amazon.AutoScaling.Model.DescribeLifecycleHooksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetASLifecycleHookCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter LifecycleHookName
        /// <summary>
        /// <para>
        /// <para>The names of one or more lifecycle hooks. If you omit this parameter, all lifecycle
        /// hooks are described.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("LifecycleHookNames")]
        public System.String[] LifecycleHookName { get; set; }
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
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            if (this.LifecycleHookName != null)
            {
                context.LifecycleHookNames = new List<System.String>(this.LifecycleHookName);
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
            var request = new Amazon.AutoScaling.Model.DescribeLifecycleHooksRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.LifecycleHookNames != null)
            {
                request.LifecycleHookNames = cmdletContext.LifecycleHookNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.LifecycleHooks;
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
        
        private Amazon.AutoScaling.Model.DescribeLifecycleHooksResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.DescribeLifecycleHooksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Auto Scaling", "DescribeLifecycleHooks");
            try
            {
                #if DESKTOP
                return client.DescribeLifecycleHooks(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeLifecycleHooksAsync(request);
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
            public System.String AutoScalingGroupName { get; set; }
            public List<System.String> LifecycleHookNames { get; set; }
        }
        
    }
}
