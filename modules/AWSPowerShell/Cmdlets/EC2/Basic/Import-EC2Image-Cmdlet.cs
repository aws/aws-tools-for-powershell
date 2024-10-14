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
    /// <note><para>
    /// To import your virtual machines (VMs) with a console-based experience, you can use
    /// the <i>Import virtual machine images to Amazon Web Services</i> template in the <a href="https://console.aws.amazon.com/migrationhub/orchestrator">Migration Hub Orchestrator
    /// console</a>. For more information, see the <a href="https://docs.aws.amazon.com/migrationhub-orchestrator/latest/userguide/import-vm-images.html"><i>Migration Hub Orchestrator User Guide</i></a>.
    /// </para></note><para>
    /// Import single or multi-volume disk images or EBS snapshots into an Amazon Machine
    /// Image (AMI).
    /// </para><important><para>
    /// Amazon Web Services VM Import/Export strongly recommends specifying a value for either
    /// the <c>--license-type</c> or <c>--usage-operation</c> parameter when you create a
    /// new VM Import task. This ensures your operating system is licensed appropriately and
    /// your billing is optimized.
    /// </para></important><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vm-import/latest/userguide/vmimport-image-import.html">Importing
    /// a VM as an image using VM Import/Export</a> in the <i>VM Import/Export User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ImportImageResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ImportImage API operation.", Operation = new[] {"ImportImage"}, SelectReturnType = typeof(Amazon.EC2.Model.ImportImageResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ImportImageResponse",
        "This cmdlet returns an Amazon.EC2.Model.ImportImageResponse object containing multiple properties."
    )]
    public partial class ImportEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>The architecture of the virtual machine.</para><para>Valid values: <c>i386</c> | <c>x86_64</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Architecture { get; set; }
        #endregion
        
        #region Parameter BootMode
        /// <summary>
        /// <para>
        /// <para>The boot mode of the virtual machine.</para><note><para>The <c>uefi-preferred</c> boot mode isn't supported for importing images. For more
        /// information, see <a href="https://docs.aws.amazon.com/vm-import/latest/userguide/prerequisites.html#vmimport-boot-modes">Boot
        /// modes</a> in the <i>VM Import/Export User Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.BootModeValues")]
        public Amazon.EC2.BootModeValues BootMode { get; set; }
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
        /// default KMS key for EBS is used unless you specify a non-default KMS key using <c>KmsKeyId</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSEncryption.html">Amazon
        /// EBS Encryption</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Encrypted { get; set; }
        #endregion
        
        #region Parameter Hypervisor
        /// <summary>
        /// <para>
        /// <para>The target hypervisor platform.</para><para>Valid values: <c>xen</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Hypervisor { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>An identifier for the symmetric KMS key to use when creating the encrypted AMI. This
        /// parameter is only required if you want to use a non-default KMS key; if this parameter
        /// is not specified, the default KMS key for EBS is used. If a <c>KmsKeyId</c> is specified,
        /// the <c>Encrypted</c> flag must also be set. </para><para>The KMS key identifier may be provided in any of the following formats: </para><ul><li><para>Key ID</para></li><li><para>Key alias</para></li><li><para>ARN using key ID. The ID ARN contains the <c>arn:aws:kms</c> namespace, followed by
        /// the Region of the key, the Amazon Web Services account ID of the key owner, the <c>key</c>
        /// namespace, and then the key ID. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:key/<i>abcd1234-a123-456a-a12b-a123b4cd56ef</i>.</para></li><li><para>ARN using key alias. The alias ARN contains the <c>arn:aws:kms</c> namespace, followed
        /// by the Region of the key, the Amazon Web Services account ID of the key owner, the
        /// <c>alias</c> namespace, and then the key alias. For example, arn:aws:kms:<i>us-east-1</i>:<i>012345678910</i>:alias/<i>ExampleAlias</i>.
        /// </para></li></ul><para>Amazon Web Services parses <c>KmsKeyId</c> asynchronously, meaning that the action
        /// you call may appear to complete even though you provided an invalid identifier. This
        /// action will eventually report failure. </para><para>The specified KMS key must exist in the Region that the AMI is being copied to.</para><para>Amazon EBS does not support asymmetric KMS keys.</para>
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
        /// <para>The license type to be used for the Amazon Machine Image (AMI) after importing.</para><para>Specify <c>AWS</c> to replace the source-system license with an Amazon Web Services
        /// license or <c>BYOL</c> to retain the source-system license. Leaving this parameter
        /// undefined is the same as choosing <c>AWS</c> when importing a Windows Server operating
        /// system, and the same as choosing <c>BYOL</c> when importing a Windows client operating
        /// system (such as Windows 10) or a Linux operating system.</para><para>To use <c>BYOL</c>, you must have existing licenses with rights to use these licenses
        /// in a third party cloud, such as Amazon Web Services. For more information, see <a href="https://docs.aws.amazon.com/vm-import/latest/userguide/vmimport-image-import.html#prerequisites-image">Prerequisites</a>
        /// in the VM Import/Export User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseType { get; set; }
        #endregion
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The operating system of the virtual machine. If you import a VM that is compatible
        /// with Unified Extensible Firmware Interface (UEFI) using an EBS snapshot, you must
        /// specify a value for the platform.</para><para>Valid values: <c>Windows</c> | <c>Linux</c></para>
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
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the import image task during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
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
        
        #region Parameter UsageOperation
        /// <summary>
        /// <para>
        /// <para>The usage operation value. For more information, see <a href="https://docs.aws.amazon.com/vm-import/latest/userguide/vmie_prereqs.html#prerequisites">Licensing
        /// options</a> in the <i>VM Import/Export User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UsageOperation { get; set; }
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
            this._AWSSignerType = "v4";
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
            context.BootMode = this.BootMode;
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
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.UsageOperation = this.UsageOperation;
            
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
            if (cmdletContext.BootMode != null)
            {
                request.BootMode = cmdletContext.BootMode;
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
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.UsageOperation != null)
            {
                request.UsageOperation = cmdletContext.UsageOperation;
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
            public Amazon.EC2.BootModeValues BootMode { get; set; }
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
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String UsageOperation { get; set; }
            public System.Func<Amazon.EC2.Model.ImportImageResponse, ImportEC2ImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
