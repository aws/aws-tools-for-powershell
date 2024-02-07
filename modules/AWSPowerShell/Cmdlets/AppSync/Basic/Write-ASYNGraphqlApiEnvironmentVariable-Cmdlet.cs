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
    /// Creates a list of environmental variables in an API by its ID value. 
    /// 
    ///  
    /// <para>
    /// When creating an environmental variable, it must follow the constraints below:
    /// </para><ul><li><para>
    /// Both JavaScript and VTL templates support environmental variables.
    /// </para></li><li><para>
    /// Environmental variables are not evaluated before function invocation.
    /// </para></li><li><para>
    /// Environmental variables only support string values.
    /// </para></li><li><para>
    /// Any defined value in an environmental variable is considered a string literal and
    /// not expanded.
    /// </para></li><li><para>
    /// Variable evaluations should ideally be performed in the function code.
    /// </para></li></ul><para>
    /// When creating an environmental variable key-value pair, it must follow the additional
    /// constraints below:
    /// </para><ul><li><para>
    /// Keys must begin with a letter.
    /// </para></li><li><para>
    /// Keys must be at least two characters long.
    /// </para></li><li><para>
    /// Keys can only contain letters, numbers, and the underscore character (_).
    /// </para></li><li><para>
    /// Values can be up to 512 characters long.
    /// </para></li><li><para>
    /// You can configure up to 50 key-value pairs in a GraphQL API.
    /// </para></li></ul><para>
    /// You can create a list of environmental variables by adding it to the <c>environmentVariables</c>
    /// payload as a list in the format <c>{"key1":"value1","key2":"value2", …}</c>. Note
    /// that each call of the <c>PutGraphqlApiEnvironmentVariables</c> action will result
    /// in the overwriting of the existing environmental variable list of that API. This means
    /// the existing environmental variables will be lost. To avoid this, you must include
    /// all existing and new environmental variables in the list each time you call this action.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASYNGraphqlApiEnvironmentVariable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS AppSync PutGraphqlApiEnvironmentVariables API operation.", Operation = new[] {"PutGraphqlApiEnvironmentVariables"}, SelectReturnType = typeof(Amazon.AppSync.Model.PutGraphqlApiEnvironmentVariablesResponse))]
    [AWSCmdletOutput("System.String or Amazon.AppSync.Model.PutGraphqlApiEnvironmentVariablesResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.AppSync.Model.PutGraphqlApiEnvironmentVariablesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteASYNGraphqlApiEnvironmentVariableCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The ID of the API to which the environmental variable list will be written.</para>
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
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>The list of environmental variables to add to the API.</para><para>When creating an environmental variable key-value pair, it must follow the additional
        /// constraints below:</para><ul><li><para>Keys must begin with a letter.</para></li><li><para>Keys must be at least two characters long.</para></li><li><para>Keys can only contain letters, numbers, and the underscore character (_).</para></li><li><para>Values can be up to 512 characters long.</para></li><li><para>You can configure up to 50 key-value pairs in a GraphQL API.</para></li></ul><para>You can create a list of environmental variables by adding it to the <c>environmentVariables</c>
        /// payload as a list in the format <c>{"key1":"value1","key2":"value2", …}</c>. Note
        /// that each call of the <c>PutGraphqlApiEnvironmentVariables</c> action will result
        /// in the overwriting of the existing environmental variable list of that API. This means
        /// the existing environmental variables will be lost. To avoid this, you must include
        /// all existing and new environmental variables in the list each time you call this action.</para>
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
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnvironmentVariables'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.PutGraphqlApiEnvironmentVariablesResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.PutGraphqlApiEnvironmentVariablesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnvironmentVariables";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApiId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApiId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApiId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApiId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASYNGraphqlApiEnvironmentVariable (PutGraphqlApiEnvironmentVariables)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.PutGraphqlApiEnvironmentVariablesResponse, WriteASYNGraphqlApiEnvironmentVariableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApiId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EnvironmentVariable != null)
            {
                context.EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentVariable.Keys)
                {
                    context.EnvironmentVariable.Add((String)hashKey, (System.String)(this.EnvironmentVariable[hashKey]));
                }
            }
            #if MODULAR
            if (this.EnvironmentVariable == null && ParameterWasBound(nameof(this.EnvironmentVariable)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentVariable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppSync.Model.PutGraphqlApiEnvironmentVariablesRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.EnvironmentVariable != null)
            {
                request.EnvironmentVariables = cmdletContext.EnvironmentVariable;
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
        
        private Amazon.AppSync.Model.PutGraphqlApiEnvironmentVariablesResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.PutGraphqlApiEnvironmentVariablesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "PutGraphqlApiEnvironmentVariables");
            try
            {
                #if DESKTOP
                return client.PutGraphqlApiEnvironmentVariables(request);
                #elif CORECLR
                return client.PutGraphqlApiEnvironmentVariablesAsync(request).GetAwaiter().GetResult();
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
            public System.String ApiId { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariable { get; set; }
            public System.Func<Amazon.AppSync.Model.PutGraphqlApiEnvironmentVariablesResponse, WriteASYNGraphqlApiEnvironmentVariableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnvironmentVariables;
        }
        
    }
}
