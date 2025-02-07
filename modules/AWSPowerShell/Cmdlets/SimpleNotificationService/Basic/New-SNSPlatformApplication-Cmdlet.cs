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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Creates a platform application object for one of the supported push notification services,
    /// such as APNS and GCM (Firebase Cloud Messaging), to which devices and mobile apps
    /// may register. You must specify <c>PlatformPrincipal</c> and <c>PlatformCredential</c>
    /// attributes when using the <c>CreatePlatformApplication</c> action.
    /// 
    ///  
    /// <para><c>PlatformPrincipal</c> and <c>PlatformCredential</c> are received from the notification
    /// service.
    /// </para><ul><li><para>
    /// For ADM, <c>PlatformPrincipal</c> is <c>client id</c> and <c>PlatformCredential</c>
    /// is <c>client secret</c>.
    /// </para></li><li><para>
    /// For APNS and <c>APNS_SANDBOX</c> using certificate credentials, <c>PlatformPrincipal</c>
    /// is <c>SSL certificate</c> and <c>PlatformCredential</c> is <c>private key</c>.
    /// </para></li><li><para>
    /// For APNS and <c>APNS_SANDBOX</c> using token credentials, <c>PlatformPrincipal</c>
    /// is <c>signing key ID</c> and <c>PlatformCredential</c> is <c>signing key</c>.
    /// </para></li><li><para>
    /// For Baidu, <c>PlatformPrincipal</c> is <c>API key</c> and <c>PlatformCredential</c>
    /// is <c>secret key</c>.
    /// </para></li><li><para>
    /// For GCM (Firebase Cloud Messaging) using key credentials, there is no <c>PlatformPrincipal</c>.
    /// The <c>PlatformCredential</c> is <c>API key</c>.
    /// </para></li><li><para>
    /// For GCM (Firebase Cloud Messaging) using token credentials, there is no <c>PlatformPrincipal</c>.
    /// The <c>PlatformCredential</c> is a JSON formatted private key file. When using the
    /// Amazon Web Services CLI, the file must be in string format and special characters
    /// must be ignored. To format the file correctly, Amazon SNS recommends using the following
    /// command: <c>SERVICE_JSON=`jq @json &lt;&lt;&lt; cat service.json`</c>.
    /// </para></li><li><para>
    /// For MPNS, <c>PlatformPrincipal</c> is <c>TLS certificate</c> and <c>PlatformCredential</c>
    /// is <c>private key</c>.
    /// </para></li><li><para>
    /// For WNS, <c>PlatformPrincipal</c> is <c>Package Security Identifier</c> and <c>PlatformCredential</c>
    /// is <c>secret key</c>.
    /// </para></li></ul><para>
    /// You can use the returned <c>PlatformApplicationArn</c> as an attribute for the <c>CreatePlatformEndpoint</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SNSPlatformApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service (SNS) CreatePlatformApplication API operation.", Operation = new[] {"CreatePlatformApplication"}, SelectReturnType = typeof(Amazon.SimpleNotificationService.Model.CreatePlatformApplicationResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleNotificationService.Model.CreatePlatformApplicationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleNotificationService.Model.CreatePlatformApplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSNSPlatformApplicationCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>For a list of attributes, see <a href="https://docs.aws.amazon.com/sns/latest/api/API_SetPlatformApplicationAttributes.html"><c>SetPlatformApplicationAttributes</c></a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Application names must be made up of only uppercase and lowercase ASCII letters, numbers,
        /// underscores, hyphens, and periods, and must be between 1 and 256 characters long.</para>
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
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The following platforms are supported: ADM (Amazon Device Messaging), APNS (Apple
        /// Push Notification Service), APNS_SANDBOX, and GCM (Firebase Cloud Messaging).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Platform { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PlatformApplicationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleNotificationService.Model.CreatePlatformApplicationResponse).
        /// Specifying the name of a property of type Amazon.SimpleNotificationService.Model.CreatePlatformApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PlatformApplicationArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SNSPlatformApplication (CreatePlatformApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleNotificationService.Model.CreatePlatformApplicationResponse, NewSNSPlatformApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            #if MODULAR
            if (this.Attribute == null && ParameterWasBound(nameof(this.Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Platform = this.Platform;
            #if MODULAR
            if (this.Platform == null && ParameterWasBound(nameof(this.Platform)))
            {
                WriteWarning("You are passing $null as a value for parameter Platform which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleNotificationService.Model.CreatePlatformApplicationRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Platform != null)
            {
                request.Platform = cmdletContext.Platform;
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
        
        private Amazon.SimpleNotificationService.Model.CreatePlatformApplicationResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.CreatePlatformApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service (SNS)", "CreatePlatformApplication");
            try
            {
                #if DESKTOP
                return client.CreatePlatformApplication(request);
                #elif CORECLR
                return client.CreatePlatformApplicationAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String Name { get; set; }
            public System.String Platform { get; set; }
            public System.Func<Amazon.SimpleNotificationService.Model.CreatePlatformApplicationResponse, NewSNSPlatformApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PlatformApplicationArn;
        }
        
    }
}
