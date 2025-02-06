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
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// When you create an extension or configure an Amazon Web Services authored extension,
    /// you associate the extension with an AppConfig application, environment, or configuration
    /// profile. For example, you can choose to run the <c>AppConfig deployment events to
    /// Amazon SNS</c> Amazon Web Services authored extension and receive notifications on
    /// an Amazon SNS topic anytime a configuration deployment is started for a specific application.
    /// Defining which extension to associate with an AppConfig resource is called an <i>extension
    /// association</i>. An extension association is a specified relationship between an extension
    /// and an AppConfig resource, such as an application or a configuration profile. For
    /// more information about extensions and associations, see <a href="https://docs.aws.amazon.com/appconfig/latest/userguide/working-with-appconfig-extensions.html">Extending
    /// workflows</a> in the <i>AppConfig User Guide</i>.
    /// </summary>
    [Cmdlet("New", "APPCExtensionAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.CreateExtensionAssociationResponse")]
    [AWSCmdlet("Calls the AWS AppConfig CreateExtensionAssociation API operation.", Operation = new[] {"CreateExtensionAssociation"}, SelectReturnType = typeof(Amazon.AppConfig.Model.CreateExtensionAssociationResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.CreateExtensionAssociationResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.CreateExtensionAssociationResponse object containing multiple properties."
    )]
    public partial class NewAPPCExtensionAssociationCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter ExtensionVersionNumber
        /// <summary>
        /// <para>
        /// <para>The version number of the extension. If not specified, AppConfig uses the maximum
        /// version of the extension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ExtensionVersionNumber { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameter names and values defined in the extensions. Extension parameters marked
        /// <c>Required</c> must be entered for this field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of an application, configuration profile, or environment.</para>
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
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds one or more tags for the specified extension association. Tags are metadata that
        /// help you categorize resources in different ways, for example, by purpose, owner, or
        /// environment. Each tag consists of a key and an optional value, both of which you define.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.CreateExtensionAssociationResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.CreateExtensionAssociationResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExtensionIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APPCExtensionAssociation (CreateExtensionAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.CreateExtensionAssociationResponse, NewAPPCExtensionAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExtensionIdentifier = this.ExtensionIdentifier;
            #if MODULAR
            if (this.ExtensionIdentifier == null && ParameterWasBound(nameof(this.ExtensionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ExtensionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExtensionVersionNumber = this.ExtensionVersionNumber;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (System.String)(this.Parameter[hashKey]));
                }
            }
            context.ResourceIdentifier = this.ResourceIdentifier;
            #if MODULAR
            if (this.ResourceIdentifier == null && ParameterWasBound(nameof(this.ResourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppConfig.Model.CreateExtensionAssociationRequest();
            
            if (cmdletContext.ExtensionIdentifier != null)
            {
                request.ExtensionIdentifier = cmdletContext.ExtensionIdentifier;
            }
            if (cmdletContext.ExtensionVersionNumber != null)
            {
                request.ExtensionVersionNumber = cmdletContext.ExtensionVersionNumber.Value;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
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
        
        private Amazon.AppConfig.Model.CreateExtensionAssociationResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.CreateExtensionAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "CreateExtensionAssociation");
            try
            {
                #if DESKTOP
                return client.CreateExtensionAssociation(request);
                #elif CORECLR
                return client.CreateExtensionAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String ExtensionIdentifier { get; set; }
            public System.Int32? ExtensionVersionNumber { get; set; }
            public Dictionary<System.String, System.String> Parameter { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AppConfig.Model.CreateExtensionAssociationResponse, NewAPPCExtensionAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
