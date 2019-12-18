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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Import single or multi-volume disk images or EBS snapshots into an Amazon Machine
    /// Image (AMI). For more information, see <a href="https://docs.aws.amazon.com/vm-import/latest/userguide/vmimport-image-import.html">Importing
    /// a VM as an Image Using VM Import/Export</a> in the <i>VM Import/Export User Guide</i>.
    /// </summary>
    [Cmdlet("Import", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ImportImageResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ImportImage API operation.", Operation = new[] {"ImportImage"}, SelectReturnType = typeof(Amazon.EC2.Model.ImportImageResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ImportImageResponse",
        "This cmdlet returns an Amazon.EC2.Model.ImportImageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>The architecture of the virtual machine.</para><para>Valid values: <code>i386</code> | <code>x86_64</code> | <code>arm64</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Architecture { get; set; }
        #endregion
        
        #region Parameter ClientData_Comment
        /// <summary>
        /// <para>
        /// <para>A user-defined comment about the disk upload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientData_Comment { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description string for the import image task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DiskContainer
        /// <summary>
        /// <para>
        /// <para>Information about the disk containers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiskContainers")]
        public Amazon.EC2.Model.ImageDiskContainer[] DiskContainer { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>Specifies whether the destination AMI of the imported image should be encrypted. The
        /// default CMK for EBS is used unless you specify a non-default AWS Key Management Service
        /// (AWS KMS) CMK using <code>KmsKeyId</code>. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSEncryption.html">Amazon
        /// EBS Encryption</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Encrypted { get; set; }
        #endregion
        
        #region Parameter Hypervisor
        /// <summary>
        /// <para>
        /// <para>The target hypervisor platform.</para><para>Valid values: <code>xen</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Hypervisor { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>An identifier for the AWS Key Management Service (AWS KMS) customer master key (CMK)
        /// to use when creating the encrypted AMI. This parameter is only required if you want
        /// to use a non-default CMK; if this parameter is not specified, the default CMK for
        /// EBS is used. If a <code>KmsKeyId</code> is specified, the <code>Encrypted</code> flag
        /// must also be set. </para><para>The CMK identifier may be provided in any of the following formats: </para><ul><li><para>Key ID</para></li><li><para>Key alias. The alias ARN contains the <code>arn:aws:kms</code> namespace, followed
        /// by the Region of the CMK, the AWS account ID of the CMK owner, the <code>alias</code>
        /// namespace, and then the CMK alias. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:alias/<i>ExampleAlias</i>.</para></li><li><para>ARN using key ID. The ID ARN contains the <code>arn:aws:kms</code> namespace, followed
        /// by the Region of the CMK, the AWS account ID of the CMK owner, the <code>key</code>
        /// namespace, and then the CMK ID. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:key/<i>abcd1234-a123-456a-a12b-a123b4cd56ef</i>.</para></li><li><para>ARN using key alias. The alias ARN contains the <code>arn:aws:kms</code> namespace,
        /// followed by the Region of the CMK, the AWS account ID of the CMK owner, the <code>alias</code>
        /// namespace, and then the CMK alias. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:alias/<i>ExampleAlias</i>.
        /// </para></li></ul><para>AWS parses <code>KmsKeyId</code> asynchronously, meaning that the action you call
        /// may appear to complete even though you provided an invalid identifier. This action
        /// will eventually report failure. </para><para>The specified CMK must exist in the Region that the AMI is being copied to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LicenseSpecification
        /// <summary>
        /// <para>
        /// <para>The ARNs of the license configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LicenseSpecifications")]
        public Amazon.EC2.Model.ImportImageLicenseConfigurationRequest[] LicenseSpecification { get; set; }
        #endregion
        
        #region Parameter LicenseType
        /// <summary>
        /// <para>
        /// <para>The license type to be used for the Amazon Machine Image (AMI) after importing.</para><para>By default, we detect the source-system operating system (OS) and apply the appropriate
        /// license. Specify <code>AWS</code> to replace the source-system license with an AWS
        /// license, if appropriate. Specify <code>BYOL</code> to retain the source-system license,
        /// if appropriate.</para><para>To use <code>BYOL</code>, you must have existing licenses with rights to use these
        /// licenses in a third party cloud, such as AWS. For more information, see <a href="https://docs.aws.amazon.com/vm-import/latest/userguide/vmimport-image-import.html#prerequisites-image">Prerequisites</a>
        /// in the VM Import/Export User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseType { get; set; }
        #endregion
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The operating system of the virtual machine.</para><para>Valid values: <code>Windows</code> | <code>Linux</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Platform { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the role to use when not using the default role, 'vmimport'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter ClientData_UtcUploadEnd
        /// <summary>
        /// <para>
        /// <para>The time that the disk upload ends.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ClientData_UtcUploadEnd { get; set; }
        #endregion
        
        #region Parameter ClientData_UploadSize
        /// <summary>
        /// <para>
        /// <para>The size of the uploaded disk image, in GiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ClientData_UploadSize { get; set; }
        #endregion
        
        #region Parameter ClientData_UtcUploadStart
        /// <summary>
        /// <para>
        /// <para>The time that the disk upload starts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ClientData_UtcUploadStart { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The token to enable idempotency for VM import requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter ClientData_UploadEnd
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use UploadEndUtc instead. Setting either UploadEnd or
        /// UploadEndUtc results in both UploadEnd and UploadEndUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. UploadEnd
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The time that the disk upload ends.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use ClientData_UtcUploadEnd instead.")]
        public System.DateTime? ClientData_UploadEnd { get; set; }
        #endregion
        
        #region Parameter ClientData_UploadStart
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use UploadStartUtc instead. Setting either UploadStart
        /// or UploadStartUtc results in both UploadStart and UploadStartUtc being assigned, the
        /// latest assignment to either one of the two property is reflected in the value of both.
        /// UploadStart is provided for backwards compatibility only and assigning a non-Utc DateTime
        /// to it results in the wrong timestamp being passed to the service.</para><para>The time that the disk upload starts.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use ClientData_UtcUploadStart instead.")]
        public System.DateTime? ClientData_UploadStart { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ImportImageResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ImportImageResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-EC2Image (ImportImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ImportImageResponse, ImportEC2ImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Architecture = this.Architecture;
            context.ClientData_Comment = this.ClientData_Comment;
            context.ClientData_UtcUploadEnd = this.ClientData_UtcUploadEnd;
            context.ClientData_UploadSize = this.ClientData_UploadSize;
            context.ClientData_UtcUploadStart = this.ClientData_UtcUploadStart;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientData_UploadEnd = this.ClientData_UploadEnd;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientData_UploadStart = this.ClientData_UploadStart;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.DiskContainer != null)
            {
                context.DiskContainer = new List<Amazon.EC2.Model.ImageDiskContainer>(this.DiskContainer);
            }
            context.Encrypted = this.Encrypted;
            context.Hypervisor = this.Hypervisor;
            context.KmsKeyId = this.KmsKeyId;
            if (this.LicenseSpecification != null)
            {
                context.LicenseSpecification = new List<Amazon.EC2.Model.ImportImageLicenseConfigurationRequest>(this.LicenseSpecification);
            }
            context.LicenseType = this.LicenseType;
            context.Platform = this.Platform;
            context.RoleName = this.RoleName;
            
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
            var request = new Amazon.EC2.Model.ImportImageRequest();
            
            if (cmdletContext.Architecture != null)
            {
                request.Architecture = cmdletContext.Architecture;
            }
            
             // populate ClientData
            var requestClientDataIsNull = true;
            request.ClientData = new Amazon.EC2.Model.ClientData();
            System.String requestClientData_clientData_Comment = null;
            if (cmdletContext.ClientData_Comment != null)
            {
                requestClientData_clientData_Comment = cmdletContext.ClientData_Comment;
            }
            if (requestClientData_clientData_Comment != null)
            {
                request.ClientData.Comment = requestClientData_clientData_Comment;
                requestClientDataIsNull = false;
            }
            System.DateTime? requestClientData_clientData_UtcUploadEnd = null;
            if (cmdletContext.ClientData_UtcUploadEnd != null)
            {
                requestClientData_clientData_UtcUploadEnd = cmdletContext.ClientData_UtcUploadEnd.Value;
            }
            if (requestClientData_clientData_UtcUploadEnd != null)
            {
                request.ClientData.UploadEndUtc = requestClientData_clientData_UtcUploadEnd.Value;
                requestClientDataIsNull = false;
            }
            System.Double? requestClientData_clientData_UploadSize = null;
            if (cmdletContext.ClientData_UploadSize != null)
            {
                requestClientData_clientData_UploadSize = cmdletContext.ClientData_UploadSize.Value;
            }
            if (requestClientData_clientData_UploadSize != null)
            {
                request.ClientData.UploadSize = requestClientData_clientData_UploadSize.Value;
                requestClientDataIsNull = false;
            }
            System.DateTime? requestClientData_clientData_UtcUploadStart = null;
            if (cmdletContext.ClientData_UtcUploadStart != null)
            {
                requestClientData_clientData_UtcUploadStart = cmdletContext.ClientData_UtcUploadStart.Value;
            }
            if (requestClientData_clientData_UtcUploadStart != null)
            {
                request.ClientData.UploadStartUtc = requestClientData_clientData_UtcUploadStart.Value;
                requestClientDataIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestClientData_clientData_UploadEnd = null;
            if (cmdletContext.ClientData_UploadEnd != null)
            {
                if (cmdletContext.ClientData_UtcUploadEnd != null)
                {
                    throw new System.ArgumentException("Parameters ClientData_UploadEnd and ClientData_UtcUploadEnd are mutually exclusive.", nameof(this.ClientData_UploadEnd));
                }
                requestClientData_clientData_UploadEnd = cmdletContext.ClientData_UploadEnd.Value;
            }
            if (requestClientData_clientData_UploadEnd != null)
            {
                request.ClientData.UploadEnd = requestClientData_clientData_UploadEnd.Value;
                requestClientDataIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestClientData_clientData_UploadStart = null;
            if (cmdletContext.ClientData_UploadStart != null)
            {
                if (cmdletContext.ClientData_UtcUploadStart != null)
                {
                    throw new System.ArgumentException("Parameters ClientData_UploadStart and ClientData_UtcUploadStart are mutually exclusive.", nameof(this.ClientData_UploadStart));
                }
                requestClientData_clientData_UploadStart = cmdletContext.ClientData_UploadStart.Value;
            }
            if (requestClientData_clientData_UploadStart != null)
            {
                request.ClientData.UploadStart = requestClientData_clientData_UploadStart.Value;
                requestClientDataIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if request.ClientData should be set to null
            if (requestClientDataIsNull)
            {
                request.ClientData = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DiskContainer != null)
            {
                request.DiskContainers = cmdletContext.DiskContainer;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.Hypervisor != null)
            {
                request.Hypervisor = cmdletContext.Hypervisor;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LicenseSpecification != null)
            {
                request.LicenseSpecifications = cmdletContext.LicenseSpecification;
            }
            if (cmdletContext.LicenseType != null)
            {
                request.LicenseType = cmdletContext.LicenseType;
            }
            if (cmdletContext.Platform != null)
            {
                request.Platform = cmdletContext.Platform;
            }
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
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
        
        private Amazon.EC2.Model.ImportImageResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ImportImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ImportImage");
            try
            {
                #if DESKTOP
                return client.ImportImage(request);
                #elif CORECLR
                return client.ImportImageAsync(request).GetAwaiter().GetResult();
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
            public System.String Architecture { get; set; }
            public System.String ClientData_Comment { get; set; }
            public System.DateTime? ClientData_UtcUploadEnd { get; set; }
            public System.Double? ClientData_UploadSize { get; set; }
            public System.DateTime? ClientData_UtcUploadStart { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? ClientData_UploadEnd { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? ClientData_UploadStart { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.EC2.Model.ImageDiskContainer> DiskContainer { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.String Hypervisor { get; set; }
            public System.String KmsKeyId { get; set; }
            public List<Amazon.EC2.Model.ImportImageLicenseConfigurationRequest> LicenseSpecification { get; set; }
            public System.String LicenseType { get; set; }
            public System.String Platform { get; set; }
            public System.String RoleName { get; set; }
            public System.Func<Amazon.EC2.Model.ImportImageResponse, ImportEC2ImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
