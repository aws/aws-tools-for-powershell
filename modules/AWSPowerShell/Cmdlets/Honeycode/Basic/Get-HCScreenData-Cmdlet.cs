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
using Amazon.Honeycode;
using Amazon.Honeycode.Model;

namespace Amazon.PowerShell.Cmdlets.HC
{
    /// <summary>
    /// The GetScreenData API allows retrieval of data from a screen in a Honeycode app.
    /// The API allows setting local variables in the screen to filter, sort or otherwise
    /// affect what will be displayed on the screen.
    /// </summary>
    [Cmdlet("Get", "HCScreenData")]
    [OutputType("Amazon.Honeycode.Model.GetScreenDataResponse")]
    [AWSCmdlet("Calls the Amazon Honeycode GetScreenData API operation.", Operation = new[] {"GetScreenData"}, SelectReturnType = typeof(Amazon.Honeycode.Model.GetScreenDataResponse))]
    [AWSCmdletOutput("Amazon.Honeycode.Model.GetScreenDataResponse",
        "This cmdlet returns an Amazon.Honeycode.Model.GetScreenDataResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetHCScreenDataCmdlet : AmazonHoneycodeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The ID of the app that contains the screen.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter ScreenId
        /// <summary>
        /// <para>
        /// <para>The ID of the screen.</para>
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
        public System.String ScreenId { get; set; }
        #endregion
        
        #region Parameter Variable
        /// <summary>
        /// <para>
        /// <para> Variables are optional and are needed only if the screen requires them to render
        /// correctly. Variables are specified as a map where the key is the name of the variable
        /// as defined on the screen. The value is an object which currently has only one property,
        /// rawValue, which holds the value of the variable to be passed to the screen. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Variables")]
        public System.Collections.Hashtable Variable { get; set; }
        #endregion
        
        #region Parameter WorkbookId
        /// <summary>
        /// <para>
        /// <para>The ID of the workbook that contains the screen.</para>
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
        public System.String WorkbookId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The number of results to be returned on a single page. Specify a number between 1
        /// and 100. The maximum value is 100. </para><para> This parameter is optional. If you don't specify this parameter, the default page
        /// size is 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> This parameter is optional. If a nextToken is not specified, the API returns the
        /// first page of data. </para><para> Pagination tokens expire after 1 hour. If you use a token that was returned more
        /// than an hour back, the API will throw ValidationException. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Honeycode.Model.GetScreenDataResponse).
        /// Specifying the name of a property of type Amazon.Honeycode.Model.GetScreenDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScreenId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScreenId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScreenId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Honeycode.Model.GetScreenDataResponse, GetHCScreenDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScreenId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ScreenId = this.ScreenId;
            #if MODULAR
            if (this.ScreenId == null && ParameterWasBound(nameof(this.ScreenId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScreenId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Variable != null)
            {
                context.Variable = new Dictionary<System.String, Amazon.Honeycode.Model.VariableValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.Variable.Keys)
                {
                    context.Variable.Add((String)hashKey, (Amazon.Honeycode.Model.VariableValue)(this.Variable[hashKey]));
                }
            }
            context.WorkbookId = this.WorkbookId;
            #if MODULAR
            if (this.WorkbookId == null && ParameterWasBound(nameof(this.WorkbookId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkbookId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Honeycode.Model.GetScreenDataRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ScreenId != null)
            {
                request.ScreenId = cmdletContext.ScreenId;
            }
            if (cmdletContext.Variable != null)
            {
                request.Variables = cmdletContext.Variable;
            }
            if (cmdletContext.WorkbookId != null)
            {
                request.WorkbookId = cmdletContext.WorkbookId;
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
        
        private Amazon.Honeycode.Model.GetScreenDataResponse CallAWSServiceOperation(IAmazonHoneycode client, Amazon.Honeycode.Model.GetScreenDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Honeycode", "GetScreenData");
            try
            {
                #if DESKTOP
                return client.GetScreenData(request);
                #elif CORECLR
                return client.GetScreenDataAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ScreenId { get; set; }
            public Dictionary<System.String, Amazon.Honeycode.Model.VariableValue> Variable { get; set; }
            public System.String WorkbookId { get; set; }
            public System.Func<Amazon.Honeycode.Model.GetScreenDataResponse, GetHCScreenDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
