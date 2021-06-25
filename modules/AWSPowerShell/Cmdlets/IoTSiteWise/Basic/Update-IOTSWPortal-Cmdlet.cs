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
    /// Updates an IoT SiteWise Monitor portal.
    /// </summary>
    [Cmdlet("Update", "IOTSWPortal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.PortalStatus")]
    [AWSCmdlet("Calls the AWS IoT SiteWise UpdatePortal API operation.", Operation = new[] {"UpdatePortal"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.UpdatePortalResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.PortalStatus or Amazon.IoTSiteWise.Model.UpdatePortalResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.PortalStatus object.",
        "The service call response (type Amazon.IoTSiteWise.Model.UpdatePortalResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTSWPortalCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
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
        
        #region Parameter File_Data
        /// <summary>
        /// <para>
        /// <para>The image file contents, represented as a base64-encoded string. The file size must
        /// be less than 1 MB.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortalLogoImage_File_Data")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] File_Data { get; set; }
        #endregion
        
        #region Parameter PortalLogoImage_Id
        /// <summary>
        /// <para>
        /// <para>The ID of an existing image. Specify this parameter to keep an existing image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalLogoImage_Id { get; set; }
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
        /// <para>The email address that sends alarm notifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationSenderEmail { get; set; }
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
        /// <para>A new description for the portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalDescription { get; set; }
        #endregion
        
        #region Parameter PortalId
        /// <summary>
        /// <para>
        /// <para>The ID of the portal to update.</para>
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
        public System.String PortalId { get; set; }
        #endregion
        
        #region Parameter PortalName
        /// <summary>
        /// <para>
        /// <para>A new friendly name for the portal.</para>
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
        
        #region Parameter File_Type
        /// <summary>
        /// <para>
        /// <para>The file type of the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortalLogoImage_File_Type")]
        [AWSConstantClassSource("Amazon.IoTSiteWise.ImageFileType")]
        public Amazon.IoTSiteWise.ImageFileType File_Type { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PortalStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.UpdatePortalResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.UpdatePortalResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PortalStatus";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PortalId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PortalId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PortalId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PortalId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSWPortal (UpdatePortal)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.UpdatePortalResponse, UpdateIOTSWPortalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PortalId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Alarms_AlarmRoleArn = this.Alarms_AlarmRoleArn;
            context.Alarms_NotificationLambdaArn = this.Alarms_NotificationLambdaArn;
            context.ClientToken = this.ClientToken;
            context.NotificationSenderEmail = this.NotificationSenderEmail;
            context.PortalContactEmail = this.PortalContactEmail;
            #if MODULAR
            if (this.PortalContactEmail == null && ParameterWasBound(nameof(this.PortalContactEmail)))
            {
                WriteWarning("You are passing $null as a value for parameter PortalContactEmail which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PortalDescription = this.PortalDescription;
            context.PortalId = this.PortalId;
            #if MODULAR
            if (this.PortalId == null && ParameterWasBound(nameof(this.PortalId)))
            {
                WriteWarning("You are passing $null as a value for parameter PortalId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.File_Data = this.File_Data;
            context.File_Type = this.File_Type;
            context.PortalLogoImage_Id = this.PortalLogoImage_Id;
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
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _File_DataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.IoTSiteWise.Model.UpdatePortalRequest();
                
                
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
                if (cmdletContext.PortalContactEmail != null)
                {
                    request.PortalContactEmail = cmdletContext.PortalContactEmail;
                }
                if (cmdletContext.PortalDescription != null)
                {
                    request.PortalDescription = cmdletContext.PortalDescription;
                }
                if (cmdletContext.PortalId != null)
                {
                    request.PortalId = cmdletContext.PortalId;
                }
                
                 // populate PortalLogoImage
                var requestPortalLogoImageIsNull = true;
                request.PortalLogoImage = new Amazon.IoTSiteWise.Model.Image();
                System.String requestPortalLogoImage_portalLogoImage_Id = null;
                if (cmdletContext.PortalLogoImage_Id != null)
                {
                    requestPortalLogoImage_portalLogoImage_Id = cmdletContext.PortalLogoImage_Id;
                }
                if (requestPortalLogoImage_portalLogoImage_Id != null)
                {
                    request.PortalLogoImage.Id = requestPortalLogoImage_portalLogoImage_Id;
                    requestPortalLogoImageIsNull = false;
                }
                Amazon.IoTSiteWise.Model.ImageFile requestPortalLogoImage_portalLogoImage_File = null;
                
                 // populate File
                var requestPortalLogoImage_portalLogoImage_FileIsNull = true;
                requestPortalLogoImage_portalLogoImage_File = new Amazon.IoTSiteWise.Model.ImageFile();
                System.IO.MemoryStream requestPortalLogoImage_portalLogoImage_File_file_Data = null;
                if (cmdletContext.File_Data != null)
                {
                    _File_DataStream = new System.IO.MemoryStream(cmdletContext.File_Data);
                    requestPortalLogoImage_portalLogoImage_File_file_Data = _File_DataStream;
                }
                if (requestPortalLogoImage_portalLogoImage_File_file_Data != null)
                {
                    requestPortalLogoImage_portalLogoImage_File.Data = requestPortalLogoImage_portalLogoImage_File_file_Data;
                    requestPortalLogoImage_portalLogoImage_FileIsNull = false;
                }
                Amazon.IoTSiteWise.ImageFileType requestPortalLogoImage_portalLogoImage_File_file_Type = null;
                if (cmdletContext.File_Type != null)
                {
                    requestPortalLogoImage_portalLogoImage_File_file_Type = cmdletContext.File_Type;
                }
                if (requestPortalLogoImage_portalLogoImage_File_file_Type != null)
                {
                    requestPortalLogoImage_portalLogoImage_File.Type = requestPortalLogoImage_portalLogoImage_File_file_Type;
                    requestPortalLogoImage_portalLogoImage_FileIsNull = false;
                }
                 // determine if requestPortalLogoImage_portalLogoImage_File should be set to null
                if (requestPortalLogoImage_portalLogoImage_FileIsNull)
                {
                    requestPortalLogoImage_portalLogoImage_File = null;
                }
                if (requestPortalLogoImage_portalLogoImage_File != null)
                {
                    request.PortalLogoImage.File = requestPortalLogoImage_portalLogoImage_File;
                    requestPortalLogoImageIsNull = false;
                }
                 // determine if request.PortalLogoImage should be set to null
                if (requestPortalLogoImageIsNull)
                {
                    request.PortalLogoImage = null;
                }
                if (cmdletContext.PortalName != null)
                {
                    request.PortalName = cmdletContext.PortalName;
                }
                if (cmdletContext.RoleArn != null)
                {
                    request.RoleArn = cmdletContext.RoleArn;
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
                if( _File_DataStream != null)
                {
                    _File_DataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IoTSiteWise.Model.UpdatePortalResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.UpdatePortalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "UpdatePortal");
            try
            {
                #if DESKTOP
                return client.UpdatePortal(request);
                #elif CORECLR
                return client.UpdatePortalAsync(request).GetAwaiter().GetResult();
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
            public System.String PortalContactEmail { get; set; }
            public System.String PortalDescription { get; set; }
            public System.String PortalId { get; set; }
            public byte[] File_Data { get; set; }
            public Amazon.IoTSiteWise.ImageFileType File_Type { get; set; }
            public System.String PortalLogoImage_Id { get; set; }
            public System.String PortalName { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.UpdatePortalResponse, UpdateIOTSWPortalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PortalStatus;
        }
        
    }
}
