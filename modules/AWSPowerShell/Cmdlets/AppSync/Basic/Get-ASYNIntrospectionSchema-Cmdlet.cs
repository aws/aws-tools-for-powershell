/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Retrieves the introspection schema for a GraphQL API.
    /// </summary>
    [Cmdlet("Get", "ASYNIntrospectionSchema")]
    [OutputType("System.IO.MemoryStream")]
    [AWSCmdlet("Calls the AWS AppSync GetIntrospectionSchema API operation.", Operation = new[] {"GetIntrospectionSchema"}, SelectReturnType = typeof(Amazon.AppSync.Model.GetIntrospectionSchemaResponse))]
    [AWSCmdletOutput("System.IO.MemoryStream or Amazon.AppSync.Model.GetIntrospectionSchemaResponse",
        "This cmdlet returns a System.IO.MemoryStream object.",
        "The service call response (type Amazon.AppSync.Model.GetIntrospectionSchemaResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetASYNIntrospectionSchemaCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API ID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter Format
        /// <summary>
        /// <para>
        /// <para>The schema format: SDL or JSON.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppSync.OutputType")]
        public Amazon.AppSync.OutputType Format { get; set; }
        #endregion
        
        #region Parameter IncludeDirective
        /// <summary>
        /// <para>
        /// <para>A flag that specifies whether the schema introspection should contain directives.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeDirectives")]
        public System.Boolean? IncludeDirective { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Schema'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.GetIntrospectionSchemaResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.GetIntrospectionSchemaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Schema";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.GetIntrospectionSchemaResponse, GetASYNIntrospectionSchemaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Format = this.Format;
            #if MODULAR
            if (this.Format == null && ParameterWasBound(nameof(this.Format)))
            {
                WriteWarning("You are passing $null as a value for parameter Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncludeDirective = this.IncludeDirective;
            
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
            var request = new Amazon.AppSync.Model.GetIntrospectionSchemaRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.Format != null)
            {
                request.Format = cmdletContext.Format;
            }
            if (cmdletContext.IncludeDirective != null)
            {
                request.IncludeDirectives = cmdletContext.IncludeDirective.Value;
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
        
        private Amazon.AppSync.Model.GetIntrospectionSchemaResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.GetIntrospectionSchemaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "GetIntrospectionSchema");
            try
            {
                return client.GetIntrospectionSchemaAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApiId { get; set; }
            public Amazon.AppSync.OutputType Format { get; set; }
            public System.Boolean? IncludeDirective { get; set; }
            public System.Func<Amazon.AppSync.Model.GetIntrospectionSchemaResponse, GetASYNIntrospectionSchemaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Schema;
        }
        
    }
}
