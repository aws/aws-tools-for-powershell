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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Returns a list of resource metadata for a given list of DevEndpoint names. After calling
    /// the <code>ListDevEndpoints</code> operation, you can call this operation to access
    /// the data to which you have been granted permissions. This operation supports all IAM
    /// permissions, including permission conditions that uses tags.
    /// </summary>
    [Cmdlet("Get", "GLUEDevEndpointBatch")]
    [OutputType("Amazon.Glue.Model.BatchGetDevEndpointsResponse")]
    [AWSCmdlet("Calls the AWS Glue BatchGetDevEndpoints API operation.", Operation = new[] {"BatchGetDevEndpoints"})]
    [AWSCmdletOutput("Amazon.Glue.Model.BatchGetDevEndpointsResponse",
        "This cmdlet returns a Amazon.Glue.Model.BatchGetDevEndpointsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEDevEndpointBatchCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter DevEndpointName
        /// <summary>
        /// <para>
        /// <para>The list of DevEndpoint names, which may be the names returned from the <code>ListDevEndpoint</code>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DevEndpointNames")]
        public System.String[] DevEndpointName { get; set; }
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
            
            if (this.DevEndpointName != null)
            {
                context.DevEndpointNames = new List<System.String>(this.DevEndpointName);
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
            var request = new Amazon.Glue.Model.BatchGetDevEndpointsRequest();
            
            if (cmdletContext.DevEndpointNames != null)
            {
                request.DevEndpointNames = cmdletContext.DevEndpointNames;
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
        
        private Amazon.Glue.Model.BatchGetDevEndpointsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.BatchGetDevEndpointsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "BatchGetDevEndpoints");
            try
            {
                #if DESKTOP
                return client.BatchGetDevEndpoints(request);
                #elif CORECLR
                return client.BatchGetDevEndpointsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DevEndpointNames { get; set; }
        }
        
    }
}
