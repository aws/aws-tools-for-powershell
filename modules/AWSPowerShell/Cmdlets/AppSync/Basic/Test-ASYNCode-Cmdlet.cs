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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Evaluates the given code and returns the response. The code definition requirements
    /// depend on the specified runtime. For <code>APPSYNC_JS</code> runtimes, the code defines
    /// the request and response functions. The request function takes the incoming request
    /// after a GraphQL operation is parsed and converts it into a request configuration for
    /// the selected data source operation. The response function interprets responses from
    /// the data source and maps it to the shape of the GraphQL field output type.
    /// </summary>
    [Cmdlet("Test", "ASYNCode")]
    [OutputType("Amazon.AppSync.Model.EvaluateCodeResponse")]
    [AWSCmdlet("Calls the AWS AppSync EvaluateCode API operation.", Operation = new[] {"EvaluateCode"}, SelectReturnType = typeof(Amazon.AppSync.Model.EvaluateCodeResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.EvaluateCodeResponse",
        "This cmdlet returns an Amazon.AppSync.Model.EvaluateCodeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestASYNCodeCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Code
        /// <summary>
        /// <para>
        /// <para>The code definition to be evaluated. Note that <code>code</code> and <code>runtime</code>
        /// are both required for this action. The <code>runtime</code> value must be <code>APPSYNC_JS</code>.</para>
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
        public System.String Code { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>The map that holds all of the contextual information for your resolver invocation.
        /// A <code>context</code> is required for this action.</para>
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
        public System.String Context { get; set; }
        #endregion
        
        #region Parameter Function
        /// <summary>
        /// <para>
        /// <para>The function within the code to be evaluated. If provided, the valid values are <code>request</code>
        /// and <code>response</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Function { get; set; }
        #endregion
        
        #region Parameter Runtime_Name
        /// <summary>
        /// <para>
        /// <para>The <code>name</code> of the runtime to use. Currently, the only allowed value is
        /// <code>APPSYNC_JS</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppSync.RuntimeName")]
        public Amazon.AppSync.RuntimeName Runtime_Name { get; set; }
        #endregion
        
        #region Parameter Runtime_RuntimeVersion
        /// <summary>
        /// <para>
        /// <para>The <code>version</code> of the runtime to use. Currently, the only allowed version
        /// is <code>1.0.0</code>.</para>
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
        public System.String Runtime_RuntimeVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.EvaluateCodeResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.EvaluateCodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.EvaluateCodeResponse, TestASYNCodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Code = this.Code;
            #if MODULAR
            if (this.Code == null && ParameterWasBound(nameof(this.Code)))
            {
                WriteWarning("You are passing $null as a value for parameter Code which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Context = this.Context;
            #if MODULAR
            if (this.Context == null && ParameterWasBound(nameof(this.Context)))
            {
                WriteWarning("You are passing $null as a value for parameter Context which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Function = this.Function;
            context.Runtime_Name = this.Runtime_Name;
            #if MODULAR
            if (this.Runtime_Name == null && ParameterWasBound(nameof(this.Runtime_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Runtime_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Runtime_RuntimeVersion = this.Runtime_RuntimeVersion;
            #if MODULAR
            if (this.Runtime_RuntimeVersion == null && ParameterWasBound(nameof(this.Runtime_RuntimeVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter Runtime_RuntimeVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppSync.Model.EvaluateCodeRequest();
            
            if (cmdletContext.Code != null)
            {
                request.Code = cmdletContext.Code;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.Function != null)
            {
                request.Function = cmdletContext.Function;
            }
            
             // populate Runtime
            var requestRuntimeIsNull = true;
            request.Runtime = new Amazon.AppSync.Model.AppSyncRuntime();
            Amazon.AppSync.RuntimeName requestRuntime_runtime_Name = null;
            if (cmdletContext.Runtime_Name != null)
            {
                requestRuntime_runtime_Name = cmdletContext.Runtime_Name;
            }
            if (requestRuntime_runtime_Name != null)
            {
                request.Runtime.Name = requestRuntime_runtime_Name;
                requestRuntimeIsNull = false;
            }
            System.String requestRuntime_runtime_RuntimeVersion = null;
            if (cmdletContext.Runtime_RuntimeVersion != null)
            {
                requestRuntime_runtime_RuntimeVersion = cmdletContext.Runtime_RuntimeVersion;
            }
            if (requestRuntime_runtime_RuntimeVersion != null)
            {
                request.Runtime.RuntimeVersion = requestRuntime_runtime_RuntimeVersion;
                requestRuntimeIsNull = false;
            }
             // determine if request.Runtime should be set to null
            if (requestRuntimeIsNull)
            {
                request.Runtime = null;
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
        
        private Amazon.AppSync.Model.EvaluateCodeResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.EvaluateCodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "EvaluateCode");
            try
            {
                #if DESKTOP
                return client.EvaluateCode(request);
                #elif CORECLR
                return client.EvaluateCodeAsync(request).GetAwaiter().GetResult();
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
            public System.String Code { get; set; }
            public System.String Context { get; set; }
            public System.String Function { get; set; }
            public Amazon.AppSync.RuntimeName Runtime_Name { get; set; }
            public System.String Runtime_RuntimeVersion { get; set; }
            public System.Func<Amazon.AppSync.Model.EvaluateCodeResponse, TestASYNCodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
