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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Returns a list of resource metadata for a given list of development endpoint names.
    /// After calling the <code>ListDevEndpoints</code> operation, you can call this operation
    /// to access the data to which you have been granted permissions. This operation supports
    /// all IAM permissions, including permission conditions that uses tags.
    /// </summary>
    [Cmdlet("Get", "GLUEDevEndpointBatch")]
    [OutputType("Amazon.Glue.Model.BatchGetDevEndpointsResponse")]
    [AWSCmdlet("Calls the AWS Glue BatchGetDevEndpoints API operation.", Operation = new[] {"BatchGetDevEndpoints"}, SelectReturnType = typeof(Amazon.Glue.Model.BatchGetDevEndpointsResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.BatchGetDevEndpointsResponse",
        "This cmdlet returns an Amazon.Glue.Model.BatchGetDevEndpointsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEDevEndpointBatchCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter DevEndpointName
        /// <summary>
        /// <para>
        /// <para>The list of <code>DevEndpoint</code> names, which might be the names returned from
        /// the <code>ListDevEndpoint</code> operation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DevEndpointNames")]
        public System.String[] DevEndpointName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.BatchGetDevEndpointsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.BatchGetDevEndpointsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.BatchGetDevEndpointsResponse, GetGLUEDevEndpointBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DevEndpointName != null)
            {
                context.DevEndpointName = new List<System.String>(this.DevEndpointName);
            }
            #if MODULAR
            if (this.DevEndpointName == null && ParameterWasBound(nameof(this.DevEndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter DevEndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.BatchGetDevEndpointsRequest();
            
            if (cmdletContext.DevEndpointName != null)
            {
                request.DevEndpointNames = cmdletContext.DevEndpointName;
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
            public List<System.String> DevEndpointName { get; set; }
            public System.Func<Amazon.Glue.Model.BatchGetDevEndpointsResponse, GetGLUEDevEndpointBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
