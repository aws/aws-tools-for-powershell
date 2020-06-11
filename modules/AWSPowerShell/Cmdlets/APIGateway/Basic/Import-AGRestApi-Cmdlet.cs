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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// A feature of the API Gateway control service for creating a new API from an external
    /// API definition file.
    /// </summary>
    [Cmdlet("Import", "AGRestApi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.ImportRestApiResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway ImportRestApi API operation.", Operation = new[] {"ImportRestApi"}, SelectReturnType = typeof(Amazon.APIGateway.Model.ImportRestApiResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.ImportRestApiResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.ImportRestApiResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportAGRestApiCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>[Required] The POST request body containing external API definitions. Currently, only
        /// OpenAPI definition JSON/YAML files are supported. The maximum size of the API definition
        /// file is 6MB.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Body { get; set; }
        #endregion
        
        #region Parameter FailOnWarning
        /// <summary>
        /// <para>
        /// <para>A query parameter to indicate whether to rollback the API creation (<code>true</code>)
        /// or not (<code>false</code>) when a warning is encountered. The default value is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FailOnWarnings")]
        public System.Boolean? FailOnWarning { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A key-value map of context-specific query string parameters specifying the behavior
        /// of different API importing operations. The following shows operation-specific parameters
        /// and their supported values.</para><para> To exclude <a>DocumentationParts</a> from the import, set <code>parameters</code>
        /// as <code>ignore=documentation</code>.</para><para> To configure the endpoint type, set <code>parameters</code> as <code>endpointConfigurationTypes=EDGE</code>,
        /// <code>endpointConfigurationTypes=REGIONAL</code>, or <code>endpointConfigurationTypes=PRIVATE</code>.
        /// The default endpoint type is <code>EDGE</code>.</para><para> To handle imported <code>basepath</code>, set <code>parameters</code> as <code>basepath=ignore</code>,
        /// <code>basepath=prepend</code> or <code>basepath=split</code>.</para><para>For example, the AWS CLI command to exclude documentation from the imported API is:</para><pre><code>aws apigateway import-rest-api --parameters ignore=documentation --body
        /// 'file:///path/to/imported-api-body.json'</code></pre><para>The AWS CLI command to set the regional endpoint on the imported API is:</para><pre><code>aws apigateway import-rest-api --parameters endpointConfigurationTypes=REGIONAL
        /// --body 'file:///path/to/imported-api-body.json'</code></pre>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.ImportRestApiResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.ImportRestApiResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Parameter parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Parameter' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Parameter' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Parameter), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-AGRestApi (ImportRestApi)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.ImportRestApiResponse, ImportAGRestApiCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Parameter;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Body = this.Body;
            #if MODULAR
            if (this.Body == null && ParameterWasBound(nameof(this.Body)))
            {
                WriteWarning("You are passing $null as a value for parameter Body which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FailOnWarning = this.FailOnWarning;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (String)(this.Parameter[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _BodyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.APIGateway.Model.ImportRestApiRequest();
                
                if (cmdletContext.Body != null)
                {
                    _BodyStream = new System.IO.MemoryStream(cmdletContext.Body);
                    request.Body = _BodyStream;
                }
                if (cmdletContext.FailOnWarning != null)
                {
                    request.FailOnWarnings = cmdletContext.FailOnWarning.Value;
                }
                if (cmdletContext.Parameter != null)
                {
                    request.Parameters = cmdletContext.Parameter;
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
            finally
            {
                if( _BodyStream != null)
                {
                    _BodyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.APIGateway.Model.ImportRestApiResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.ImportRestApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "ImportRestApi");
            try
            {
                #if DESKTOP
                return client.ImportRestApi(request);
                #elif CORECLR
                return client.ImportRestApiAsync(request).GetAwaiter().GetResult();
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
            public byte[] Body { get; set; }
            public System.Boolean? FailOnWarning { get; set; }
            public Dictionary<System.String, System.String> Parameter { get; set; }
            public System.Func<Amazon.APIGateway.Model.ImportRestApiResponse, ImportAGRestApiCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
