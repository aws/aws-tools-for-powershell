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
    /// Creates an AppConfig extension. An extension augments your ability to inject logic
    /// or behavior at different points during the AppConfig workflow of creating or deploying
    /// a configuration.
    /// 
    ///  
    /// <para>
    /// You can create your own extensions or use the Amazon Web Services authored extensions
    /// provided by AppConfig. For an AppConfig extension that uses Lambda, you must create
    /// a Lambda function to perform any computation and processing defined in the extension.
    /// If you plan to create custom versions of the Amazon Web Services authored notification
    /// extensions, you only need to specify an Amazon Resource Name (ARN) in the <c>Uri</c>
    /// field for the new extension version.
    /// </para><ul><li><para>
    /// For a custom EventBridge notification extension, enter the ARN of the EventBridge
    /// default events in the <c>Uri</c> field.
    /// </para></li><li><para>
    /// For a custom Amazon SNS notification extension, enter the ARN of an Amazon SNS topic
    /// in the <c>Uri</c> field.
    /// </para></li><li><para>
    /// For a custom Amazon SQS notification extension, enter the ARN of an Amazon SQS message
    /// queue in the <c>Uri</c> field. 
    /// </para></li></ul><para>
    /// For more information about extensions, see <a href="https://docs.aws.amazon.com/appconfig/latest/userguide/working-with-appconfig-extensions.html">Extending
    /// workflows</a> in the <i>AppConfig User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "APPCExtension", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.CreateExtensionResponse")]
    [AWSCmdlet("Calls the AWS AppConfig CreateExtension API operation.", Operation = new[] {"CreateExtension"}, SelectReturnType = typeof(Amazon.AppConfig.Model.CreateExtensionResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.CreateExtensionResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.CreateExtensionResponse object containing multiple properties."
    )]
    public partial class NewAPPCExtensionCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The actions defined in the extension.</para>
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
        
        #region Parameter LatestVersionNumber
        /// <summary>
        /// <para>
        /// <para>You can omit this field when you create an extension. When you create a new version,
        /// specify the most recent current version number. For example, you create version 3,
        /// enter 2 for this field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LatestVersionNumber { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the extension. Each extension name in your account must be unique. Extension
        /// versions use the same name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters accepted by the extension. You specify parameter values when you associate
        /// the extension to an AppConfig resource by using the <c>CreateExtensionAssociation</c>
        /// API action. For Lambda extension actions, these parameters are included in the Lambda
        /// request object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds one or more tags for the specified extension. Tags are metadata that help you
        /// categorize resources in different ways, for example, by purpose, owner, or environment.
        /// Each tag consists of a key and an optional value, both of which you define. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.CreateExtensionResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.CreateExtensionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APPCExtension (CreateExtension)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.CreateExtensionResponse, NewAPPCExtensionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
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
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.LatestVersionNumber = this.LatestVersionNumber;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppConfig.Model.CreateExtensionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.LatestVersionNumber != null)
            {
                request.LatestVersionNumber = cmdletContext.LatestVersionNumber.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
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
        
        private Amazon.AppConfig.Model.CreateExtensionResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.CreateExtensionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "CreateExtension");
            try
            {
                #if DESKTOP
                return client.CreateExtension(request);
                #elif CORECLR
                return client.CreateExtensionAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? LatestVersionNumber { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, Amazon.AppConfig.Model.Parameter> Parameter { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AppConfig.Model.CreateExtensionResponse, NewAPPCExtensionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
