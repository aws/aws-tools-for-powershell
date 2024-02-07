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
    /// Updates a specified development endpoint.
    /// </summary>
    [Cmdlet("Update", "GLUEDevEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue UpdateDevEndpoint API operation.", Operation = new[] {"UpdateDevEndpoint"}, SelectReturnType = typeof(Amazon.Glue.Model.UpdateDevEndpointResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.UpdateDevEndpointResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.UpdateDevEndpointResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGLUEDevEndpointCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddArgument
        /// <summary>
        /// <para>
        /// <para>The map of arguments to add the map of arguments used to configure the <c>DevEndpoint</c>.</para><para>Valid arguments are:</para><ul><li><para><c>"--enable-glue-datacatalog": ""</c></para></li></ul><para>You can specify a version of Python support for development endpoints by using the
        /// <c>Arguments</c> parameter in the <c>CreateDevEndpoint</c> or <c>UpdateDevEndpoint</c>
        /// APIs. If no arguments are provided, the version defaults to Python 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddArguments")]
        public System.Collections.Hashtable AddArgument { get; set; }
        #endregion
        
        #region Parameter AddPublicKey
        /// <summary>
        /// <para>
        /// <para>The list of public keys for the <c>DevEndpoint</c> to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddPublicKeys")]
        public System.String[] AddPublicKey { get; set; }
        #endregion
        
        #region Parameter CustomLibrary
        /// <summary>
        /// <para>
        /// <para>Custom Python or Java libraries to be loaded in the <c>DevEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomLibraries")]
        public Amazon.Glue.Model.DevEndpointCustomLibraries CustomLibrary { get; set; }
        #endregion
        
        #region Parameter DeleteArgument
        /// <summary>
        /// <para>
        /// <para>The list of argument keys to be deleted from the map of arguments used to configure
        /// the <c>DevEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteArguments")]
        public System.String[] DeleteArgument { get; set; }
        #endregion
        
        #region Parameter DeletePublicKey
        /// <summary>
        /// <para>
        /// <para>The list of public keys to be deleted from the <c>DevEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeletePublicKeys")]
        public System.String[] DeletePublicKey { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the <c>DevEndpoint</c> to be updated.</para>
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
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter PublicKey
        /// <summary>
        /// <para>
        /// <para>The public key for the <c>DevEndpoint</c> to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PublicKey { get; set; }
        #endregion
        
        #region Parameter UpdateEtlLibrary
        /// <summary>
        /// <para>
        /// <para><c>True</c> if the list of custom libraries to be loaded in the development endpoint
        /// needs to be updated, or <c>False</c> if otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdateEtlLibraries")]
        public System.Boolean? UpdateEtlLibrary { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.UpdateDevEndpointResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EndpointName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EndpointName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EndpointName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GLUEDevEndpoint (UpdateDevEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.UpdateDevEndpointResponse, UpdateGLUEDevEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EndpointName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddArgument != null)
            {
                context.AddArgument = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AddArgument.Keys)
                {
                    context.AddArgument.Add((String)hashKey, (System.String)(this.AddArgument[hashKey]));
                }
            }
            if (this.AddPublicKey != null)
            {
                context.AddPublicKey = new List<System.String>(this.AddPublicKey);
            }
            context.CustomLibrary = this.CustomLibrary;
            if (this.DeleteArgument != null)
            {
                context.DeleteArgument = new List<System.String>(this.DeleteArgument);
            }
            if (this.DeletePublicKey != null)
            {
                context.DeletePublicKey = new List<System.String>(this.DeletePublicKey);
            }
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublicKey = this.PublicKey;
            context.UpdateEtlLibrary = this.UpdateEtlLibrary;
            
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
            var request = new Amazon.Glue.Model.UpdateDevEndpointRequest();
            
            if (cmdletContext.AddArgument != null)
            {
                request.AddArguments = cmdletContext.AddArgument;
            }
            if (cmdletContext.AddPublicKey != null)
            {
                request.AddPublicKeys = cmdletContext.AddPublicKey;
            }
            if (cmdletContext.CustomLibrary != null)
            {
                request.CustomLibraries = cmdletContext.CustomLibrary;
            }
            if (cmdletContext.DeleteArgument != null)
            {
                request.DeleteArguments = cmdletContext.DeleteArgument;
            }
            if (cmdletContext.DeletePublicKey != null)
            {
                request.DeletePublicKeys = cmdletContext.DeletePublicKey;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.PublicKey != null)
            {
                request.PublicKey = cmdletContext.PublicKey;
            }
            if (cmdletContext.UpdateEtlLibrary != null)
            {
                request.UpdateEtlLibraries = cmdletContext.UpdateEtlLibrary.Value;
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
        
        private Amazon.Glue.Model.UpdateDevEndpointResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.UpdateDevEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "UpdateDevEndpoint");
            try
            {
                #if DESKTOP
                return client.UpdateDevEndpoint(request);
                #elif CORECLR
                return client.UpdateDevEndpointAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AddArgument { get; set; }
            public List<System.String> AddPublicKey { get; set; }
            public Amazon.Glue.Model.DevEndpointCustomLibraries CustomLibrary { get; set; }
            public List<System.String> DeleteArgument { get; set; }
            public List<System.String> DeletePublicKey { get; set; }
            public System.String EndpointName { get; set; }
            public System.String PublicKey { get; set; }
            public System.Boolean? UpdateEtlLibrary { get; set; }
            public System.Func<Amazon.Glue.Model.UpdateDevEndpointResponse, UpdateGLUEDevEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
