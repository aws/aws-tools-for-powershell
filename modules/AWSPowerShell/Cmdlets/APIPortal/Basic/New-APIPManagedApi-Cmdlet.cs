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
using Amazon.APIPortal;
using Amazon.APIPortal.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APIP
{
    /// <summary>
    /// Promote a discovered API in the API inventory into the managed API list.
    /// </summary>
    [Cmdlet("New", "APIPManagedApi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIPortal.Model.CreateManagedApiResponse")]
    [AWSCmdlet("Calls the APIPortal CreateManagedApi API operation.", Operation = new[] {"CreateManagedApi"}, SelectReturnType = typeof(Amazon.APIPortal.Model.CreateManagedApiResponse))]
    [AWSCmdletOutput("Amazon.APIPortal.Model.CreateManagedApiResponse",
        "This cmdlet returns an Amazon.APIPortal.Model.CreateManagedApiResponse object containing multiple properties."
    )]
    public partial class NewAPIPManagedApiCmdlet : AmazonAPIPortalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiSignature_Hostname
        /// <summary>
        /// <para>
        /// The host name the API is served on.
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
        public System.String ApiSignature_Hostname { get; set; }
        #endregion
        
        #region Parameter ApiSignature_Method
        /// <summary>
        /// <para>
        /// The HTTP method of the API.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.APIPortal.HttpMethod")]
        public Amazon.APIPortal.HttpMethod ApiSignature_Method { get; set; }
        #endregion
        
        #region Parameter ApiSignature_Path
        /// <summary>
        /// <para>
        /// The request path of the API.
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
        public System.String ApiSignature_Path { get; set; }
        #endregion
        
        #region Parameter ApiSignature_Port
        /// <summary>
        /// <para>
        /// The port the API listens on, from 0 to 65535.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ApiSignature_Port { get; set; }
        #endregion
        
        #region Parameter ApiSignature_ResourceArn
        /// <summary>
        /// <para>
        /// The ARN of the resource that serves the API.
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
        public System.String ApiSignature_ResourceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIPortal.Model.CreateManagedApiResponse).
        /// Specifying the name of a property of type Amazon.APIPortal.Model.CreateManagedApiResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APIPManagedApi (CreateManagedApi)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIPortal.Model.CreateManagedApiResponse, NewAPIPManagedApiCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiSignature_Hostname = this.ApiSignature_Hostname;
            #if MODULAR
            if (this.ApiSignature_Hostname == null && ParameterWasBound(nameof(this.ApiSignature_Hostname)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiSignature_Hostname which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApiSignature_Method = this.ApiSignature_Method;
            #if MODULAR
            if (this.ApiSignature_Method == null && ParameterWasBound(nameof(this.ApiSignature_Method)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiSignature_Method which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApiSignature_Path = this.ApiSignature_Path;
            #if MODULAR
            if (this.ApiSignature_Path == null && ParameterWasBound(nameof(this.ApiSignature_Path)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiSignature_Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApiSignature_Port = this.ApiSignature_Port;
            #if MODULAR
            if (this.ApiSignature_Port == null && ParameterWasBound(nameof(this.ApiSignature_Port)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiSignature_Port which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApiSignature_ResourceArn = this.ApiSignature_ResourceArn;
            #if MODULAR
            if (this.ApiSignature_ResourceArn == null && ParameterWasBound(nameof(this.ApiSignature_ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiSignature_ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.APIPortal.Model.CreateManagedApiRequest();
            
            
             // populate ApiSignature
            var requestApiSignatureIsNull = true;
            request.ApiSignature = new Amazon.APIPortal.Model.ApiSignature();
            System.String requestApiSignature_apiSignature_Hostname = null;
            if (cmdletContext.ApiSignature_Hostname != null)
            {
                requestApiSignature_apiSignature_Hostname = cmdletContext.ApiSignature_Hostname;
            }
            if (requestApiSignature_apiSignature_Hostname != null)
            {
                request.ApiSignature.Hostname = requestApiSignature_apiSignature_Hostname;
                requestApiSignatureIsNull = false;
            }
            Amazon.APIPortal.HttpMethod requestApiSignature_apiSignature_Method = null;
            if (cmdletContext.ApiSignature_Method != null)
            {
                requestApiSignature_apiSignature_Method = cmdletContext.ApiSignature_Method;
            }
            if (requestApiSignature_apiSignature_Method != null)
            {
                request.ApiSignature.Method = requestApiSignature_apiSignature_Method;
                requestApiSignatureIsNull = false;
            }
            System.String requestApiSignature_apiSignature_Path = null;
            if (cmdletContext.ApiSignature_Path != null)
            {
                requestApiSignature_apiSignature_Path = cmdletContext.ApiSignature_Path;
            }
            if (requestApiSignature_apiSignature_Path != null)
            {
                request.ApiSignature.Path = requestApiSignature_apiSignature_Path;
                requestApiSignatureIsNull = false;
            }
            System.Int32? requestApiSignature_apiSignature_Port = null;
            if (cmdletContext.ApiSignature_Port != null)
            {
                requestApiSignature_apiSignature_Port = cmdletContext.ApiSignature_Port.Value;
            }
            if (requestApiSignature_apiSignature_Port != null)
            {
                request.ApiSignature.Port = requestApiSignature_apiSignature_Port.Value;
                requestApiSignatureIsNull = false;
            }
            System.String requestApiSignature_apiSignature_ResourceArn = null;
            if (cmdletContext.ApiSignature_ResourceArn != null)
            {
                requestApiSignature_apiSignature_ResourceArn = cmdletContext.ApiSignature_ResourceArn;
            }
            if (requestApiSignature_apiSignature_ResourceArn != null)
            {
                request.ApiSignature.ResourceArn = requestApiSignature_apiSignature_ResourceArn;
                requestApiSignatureIsNull = false;
            }
             // determine if request.ApiSignature should be set to null
            if (requestApiSignatureIsNull)
            {
                request.ApiSignature = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.APIPortal.Model.CreateManagedApiResponse CallAWSServiceOperation(IAmazonAPIPortal client, Amazon.APIPortal.Model.CreateManagedApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "APIPortal", "CreateManagedApi");
            try
            {
                return client.CreateManagedApiAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApiSignature_Hostname { get; set; }
            public Amazon.APIPortal.HttpMethod ApiSignature_Method { get; set; }
            public System.String ApiSignature_Path { get; set; }
            public System.Int32? ApiSignature_Port { get; set; }
            public System.String ApiSignature_ResourceArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.APIPortal.Model.CreateManagedApiResponse, NewAPIPManagedApiCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
