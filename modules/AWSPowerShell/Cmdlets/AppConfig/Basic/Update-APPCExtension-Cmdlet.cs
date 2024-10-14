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
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// Updates an AppConfig extension. For more information about extensions, see <a href="https://docs.aws.amazon.com/appconfig/latest/userguide/working-with-appconfig-extensions.html">Extending
    /// workflows</a> in the <i>AppConfig User Guide</i>.
    /// </summary>
    [Cmdlet("Update", "APPCExtension", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.UpdateExtensionResponse")]
    [AWSCmdlet("Calls the AWS AppConfig UpdateExtension API operation.", Operation = new[] {"UpdateExtension"}, SelectReturnType = typeof(Amazon.AppConfig.Model.UpdateExtensionResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.UpdateExtensionResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.UpdateExtensionResponse object containing multiple properties."
    )]
    public partial class UpdateAPPCExtensionCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The actions defined in the extension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Actions")]
        public System.Collections.Hashtable Action { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Information about the extension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExtensionIdentifier
        /// <summary>
        /// <para>
        /// <para>The name, the ID, or the Amazon Resource Name (ARN) of the extension.</para>
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
        public System.String ExtensionIdentifier { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>One or more parameters for the actions called by the extension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter VersionNumber
        /// <summary>
        /// <para>
        /// <para>The extension version number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VersionNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.UpdateExtensionResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.UpdateExtensionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExtensionIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExtensionIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExtensionIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExtensionIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APPCExtension (UpdateExtension)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.UpdateExtensionResponse, UpdateAPPCExtensionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExtensionIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Action != null)
            {
                context.Action = new Dictionary<System.String, List<Amazon.AppConfig.Model.Action>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Action.Keys)
                {
                    object hashValue = this.Action[hashKey];
                    if (hashValue == null)
                    {
                        context.Action.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.AppConfig.Model.Action>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.AppConfig.Model.Action)s);
                    }
                    context.Action.Add((String)hashKey, valueSet);
                }
            }
            context.Description = this.Description;
            context.ExtensionIdentifier = this.ExtensionIdentifier;
            #if MODULAR
            if (this.ExtensionIdentifier == null && ParameterWasBound(nameof(this.ExtensionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ExtensionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, Amazon.AppConfig.Model.Parameter>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (Amazon.AppConfig.Model.Parameter)(this.Parameter[hashKey]));
                }
            }
            context.VersionNumber = this.VersionNumber;
            
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
            var request = new Amazon.AppConfig.Model.UpdateExtensionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExtensionIdentifier != null)
            {
                request.ExtensionIdentifier = cmdletContext.ExtensionIdentifier;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.VersionNumber != null)
            {
                request.VersionNumber = cmdletContext.VersionNumber.Value;
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
        
        private Amazon.AppConfig.Model.UpdateExtensionResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.UpdateExtensionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "UpdateExtension");
            try
            {
                #if DESKTOP
                return client.UpdateExtension(request);
                #elif CORECLR
                return client.UpdateExtensionAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, List<Amazon.AppConfig.Model.Action>> Action { get; set; }
            public System.String Description { get; set; }
            public System.String ExtensionIdentifier { get; set; }
            public Dictionary<System.String, Amazon.AppConfig.Model.Parameter> Parameter { get; set; }
            public System.Int32? VersionNumber { get; set; }
            public System.Func<Amazon.AppConfig.Model.UpdateExtensionResponse, UpdateAPPCExtensionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
