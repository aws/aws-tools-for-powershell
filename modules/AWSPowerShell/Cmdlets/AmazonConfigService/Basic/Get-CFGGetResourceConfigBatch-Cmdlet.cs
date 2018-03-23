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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the current configuration for one or more requested resources. The operation
    /// also returns a list of resources that are not processed in the current request. If
    /// there are no unprocessed resources, the operation returns an empty unprocessedResourceKeys
    /// list. 
    /// 
    ///  <note><ul><li><para>
    /// The API does not return results for deleted resources.
    /// </para></li><li><para>
    ///  The API does not return any tags for the requested resources. This information is
    /// filtered out of the supplementaryConfiguration section of the API response.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Get", "CFGGetResourceConfigBatch")]
    [OutputType("Amazon.ConfigService.Model.BatchGetResourceConfigResponse")]
    [AWSCmdlet("Calls the AWS Config BatchGetResourceConfig API operation.", Operation = new[] {"BatchGetResourceConfig"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.BatchGetResourceConfigResponse",
        "This cmdlet returns a Amazon.ConfigService.Model.BatchGetResourceConfigResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGGetResourceConfigBatchCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ResourceKey
        /// <summary>
        /// <para>
        /// <para>A list of resource keys to be processed with the current request. Each element in
        /// the list consists of the resource type and resource ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("ResourceKeys")]
        public Amazon.ConfigService.Model.ResourceKey[] ResourceKey { get; set; }
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
            
            if (this.ResourceKey != null)
            {
                context.ResourceKeys = new List<Amazon.ConfigService.Model.ResourceKey>(this.ResourceKey);
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
            var request = new Amazon.ConfigService.Model.BatchGetResourceConfigRequest();
            
            if (cmdletContext.ResourceKeys != null)
            {
                request.ResourceKeys = cmdletContext.ResourceKeys;
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
        
        private Amazon.ConfigService.Model.BatchGetResourceConfigResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.BatchGetResourceConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "BatchGetResourceConfig");
            try
            {
                #if DESKTOP
                return client.BatchGetResourceConfig(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.BatchGetResourceConfigAsync(request);
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
            public List<Amazon.ConfigService.Model.ResourceKey> ResourceKeys { get; set; }
        }
        
    }
}
