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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Creates a portal, which can contain projects and dashboards. IoT SiteWise Monitor
    /// uses Amazon Web Services SSO or IAM to authenticate portal users and manage user permissions.
    /// 
    ///  <note><para>
    /// Before you can sign in to a new portal, you must add at least one identity to that
    /// portal. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/administer-portals.html#portal-change-admins">Adding
    /// or removing portal administrators</a> in the <i>IoT SiteWise User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "IOTSWPortal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.CreatePortalResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise CreatePortal API operation.", Operation = new[] {"CreatePortal"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.CreatePortalResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.CreatePortalResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.CreatePortalResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTSWPortalCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        #region Parameter Alarms_AlarmRoleArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the IAM role that allows the alarm to perform actions and access Amazon Web Services
        /// resources and services, such as IoT Events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Alarms_AlarmRoleArn { get; set; }
        #endregion
        
        #region Parameter PortalLogoImageFile_Data
        /// <summary>
        /// <para>
        /// <para>The image file contents, represented as a base64-encoded string. The file size must
        /// be less than 1 MB.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] PortalLogoImageFile_Data { get; set; }
        #endregion
        
        #region Parameter Alarms_NotificationLambdaArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the Lambda function that manages alarm notifications. For more information, see
        /// <a href="https://docs.aws.amazon.com/iotevents/latest/developerguide/lambda-support.html">Managing
        /// alarm notifications</a> in the <i>IoT Events Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Alarms_NotificationLambdaArn { get; set; }
        #endregion
        
        #region Parameter NotificationSenderEmail
        /// <summary>
        /// <para>
        /// <para>The email address that sends alarm notifications.</para><important><para>If you use the <a href="https://docs.aws.amazon.com/iotevents/latest/developerguide/lambda-support.html">IoT
        /// Events managed Lambda function</a> to manage your emails, you must <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/verify-email-addresses.html">verify
        /// the sender email address in Amazon SES</a>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationSenderEmail { get; set; }
        #endregion
        
        #region Parameter PortalAuthMode
        /// <summary>
        /// <para>
        /// <para>The service to use to authenticate users to the portal. Choose from the following
        /// options:</para><ul><li><para><code>SSO</code> – The portal uses Amazon Web Services Single Sign On to authenticate
        /// users and manage user permissions. Before you can create a portal that uses Amazon
        /// Web Services SSO, you must enable Amazon Web Services SSO. For more information, see
        /// <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/monitor-get-started.html#mon-gs-sso">Enabling
        /// Amazon Web Services SSO</a> in the <i>IoT SiteWise User Guide</i>. This option is
        /// only available in Amazon Web Services Regions other than the China Regions.</para></li><li><para><code>IAM</code> – The portal uses Identity and Access Management to authenticate
        /// users and manage user permissions.</para></li></ul><para>You can't change this value after you create a portal.</para><para>Default: <code>SSO</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.AuthMode")]
        public Amazon.IoTSiteWise.AuthMode PortalAuthMode { get; set; }
        #endregion
        
        #region Parameter PortalContactEmail
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services administrator's contact email address.</para>
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
        public System.String PortalContactEmail { get; set; }
        #endregion
        
        #region Parameter PortalDescription
        /// <summary>
        /// <para>
        /// <para>A description for the portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalDescription { get; set; }
        #endregion
        
        #region Parameter PortalName
        /// <summary>
        /// <para>
        /// <para>A friendly name for the portal.</para>
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
        public System.String PortalName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of a service role that allows the portal's users to access your IoT SiteWise resources
        /// on your behalf. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/monitor-service-role.html">Using
        /// service roles for IoT SiteWise Monitor</a> in the <i>IoT SiteWise User Guide</i>.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that contain metadata for the portal. For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/tag-resources.html">Tagging
        /// your IoT SiteWise resources</a> in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter PortalLogoImageFile_Type
        /// <summary>
        /// <para>
        /// <para>The file type of the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.ImageFileType")]
        public Amazon.IoTSiteWise.ImageFileType PortalLogoImageFile_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.CreatePortalResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.CreatePortalResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PortalName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTSWPortal (CreatePortal)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.CreatePortalResponse, NewIOTSWPortalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Alarms_AlarmRoleArn = this.Alarms_AlarmRoleArn;
            context.Alarms_NotificationLambdaArn = this.Alarms_NotificationLambdaArn;
            context.ClientToken = this.ClientToken;
            context.NotificationSenderEmail = this.NotificationSenderEmail;
            context.PortalAuthMode = this.PortalAuthMode;
            context.PortalContactEmail = this.PortalContactEmail;
            #if MODULAR
            if (this.PortalContactEmail == null && ParameterWasBound(nameof(this.PortalContactEmail)))
            {
                WriteWarning("You are passing $null as a value for parameter PortalContactEmail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PortalDescription = this.PortalDescription;
            context.PortalLogoImageFile_Data = this.PortalLogoImageFile_Data;
            context.PortalLogoImageFile_Type = this.PortalLogoImageFile_Type;
            context.PortalName = this.PortalName;
            #if MODULAR
            if (this.PortalName == null && ParameterWasBound(nameof(this.PortalName)))
            {
                WriteWarning("You are passing $null as a value for parameter PortalName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            System.IO.MemoryStream _PortalLogoImageFile_DataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.IoTSiteWise.Model.CreatePortalRequest();
                
                
                 // populate Alarms
                var requestAlarmsIsNull = true;
                request.Alarms = new Amazon.IoTSiteWise.Model.Alarms();
                System.String requestAlarms_alarms_AlarmRoleArn = null;
                if (cmdletContext.Alarms_AlarmRoleArn != null)
                {
                    requestAlarms_alarms_AlarmRoleArn = cmdletContext.Alarms_AlarmRoleArn;
                }
                if (requestAlarms_alarms_AlarmRoleArn != null)
                {
                    request.Alarms.AlarmRoleArn = requestAlarms_alarms_AlarmRoleArn;
                    requestAlarmsIsNull = false;
                }
                System.String requestAlarms_alarms_NotificationLambdaArn = null;
                if (cmdletContext.Alarms_NotificationLambdaArn != null)
                {
                    requestAlarms_alarms_NotificationLambdaArn = cmdletContext.Alarms_NotificationLambdaArn;
                }
                if (requestAlarms_alarms_NotificationLambdaArn != null)
                {
                    request.Alarms.NotificationLambdaArn = requestAlarms_alarms_NotificationLambdaArn;
                    requestAlarmsIsNull = false;
                }
                 // determine if request.Alarms should be set to null
                if (requestAlarmsIsNull)
                {
                    request.Alarms = null;
                }
                if (cmdletContext.ClientToken != null)
                {
                    request.ClientToken = cmdletContext.ClientToken;
                }
                if (cmdletContext.NotificationSenderEmail != null)
                {
                    request.NotificationSenderEmail = cmdletContext.NotificationSenderEmail;
                }
                if (cmdletContext.PortalAuthMode != null)
                {
                    request.PortalAuthMode = cmdletContext.PortalAuthMode;
                }
                if (cmdletContext.PortalContactEmail != null)
                {
                    request.PortalContactEmail = cmdletContext.PortalContactEmail;
                }
                if (cmdletContext.PortalDescription != null)
                {
                    request.PortalDescription = cmdletContext.PortalDescription;
                }
                
                 // populate PortalLogoImageFile
                var requestPortalLogoImageFileIsNull = true;
                request.PortalLogoImageFile = new Amazon.IoTSiteWise.Model.ImageFile();
                System.IO.MemoryStream requestPortalLogoImageFile_portalLogoImageFile_Data = null;
                if (cmdletContext.PortalLogoImageFile_Data != null)
                {
                    _PortalLogoImageFile_DataStream = new System.IO.MemoryStream(cmdletContext.PortalLogoImageFile_Data);
                    requestPortalLogoImageFile_portalLogoImageFile_Data = _PortalLogoImageFile_DataStream;
                }
                if (requestPortalLogoImageFile_portalLogoImageFile_Data != null)
                {
                    request.PortalLogoImageFile.Data = requestPortalLogoImageFile_portalLogoImageFile_Data;
                    requestPortalLogoImageFileIsNull = false;
                }
                Amazon.IoTSiteWise.ImageFileType requestPortalLogoImageFile_portalLogoImageFile_Type = null;
                if (cmdletContext.PortalLogoImageFile_Type != null)
                {
                    requestPortalLogoImageFile_portalLogoImageFile_Type = cmdletContext.PortalLogoImageFile_Type;
                }
                if (requestPortalLogoImageFile_portalLogoImageFile_Type != null)
                {
                    request.PortalLogoImageFile.Type = requestPortalLogoImageFile_portalLogoImageFile_Type;
                    requestPortalLogoImageFileIsNull = false;
                }
                 // determine if request.PortalLogoImageFile should be set to null
                if (requestPortalLogoImageFileIsNull)
                {
                    request.PortalLogoImageFile = null;
                }
                if (cmdletContext.PortalName != null)
                {
                    request.PortalName = cmdletContext.PortalName;
                }
                if (cmdletContext.RoleArn != null)
                {
                    request.RoleArn = cmdletContext.RoleArn;
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
            finally
            {
                if( _PortalLogoImageFile_DataStream != null)
                {
                    _PortalLogoImageFile_DataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IoTSiteWise.Model.CreatePortalResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.CreatePortalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "CreatePortal");
            try
            {
                #if DESKTOP
                return client.CreatePortal(request);
                #elif CORECLR
                return client.CreatePortalAsync(request).GetAwaiter().GetResult();
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
            public System.String Alarms_AlarmRoleArn { get; set; }
            public System.String Alarms_NotificationLambdaArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String NotificationSenderEmail { get; set; }
            public Amazon.IoTSiteWise.AuthMode PortalAuthMode { get; set; }
            public System.String PortalContactEmail { get; set; }
            public System.String PortalDescription { get; set; }
            public byte[] PortalLogoImageFile_Data { get; set; }
            public Amazon.IoTSiteWise.ImageFileType PortalLogoImageFile_Type { get; set; }
            public System.String PortalName { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.CreatePortalResponse, NewIOTSWPortalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
