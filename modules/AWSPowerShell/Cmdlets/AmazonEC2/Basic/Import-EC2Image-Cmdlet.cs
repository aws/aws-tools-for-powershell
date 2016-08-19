/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Image (AMI). For more information, see <a href="http://docs.aws.amazon.com/vm-import/latest/userguide/vmimport-image-import.html">Importing
    /// a VM as an Image Using VM Import/Export</a> in the <i>VM Import/Export User Guide</i>.
    /// </summary>
    [Cmdlet("Import", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ImportImageResponse")]
    [AWSCmdlet("Invokes the ImportImage operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ImportImage"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ImportImageResponse",
        "This cmdlet returns a Amazon.EC2.Model.ImportImageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>The architecture of the virtual machine.</para><para>Valid values: <code>i386</code> | <code>x86_64</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Architecture { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The token to enable idempotency for VM import requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter ClientData_Comment
        /// <summary>
        /// <para>
        /// <para>A user-defined comment about the disk upload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientData_Comment { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description string for the import image task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DiskContainer
        /// <summary>
        /// <para>
        /// <para>Information about the disk containers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DiskContainers")]
        public Amazon.EC2.Model.ImageDiskContainer[] DiskContainer { get; set; }
        #endregion
        
        #region Parameter Hypervisor
        /// <summary>
        /// <para>
        /// <para>The target hypervisor platform.</para><para>Valid values: <code>xen</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Hypervisor { get; set; }
        #endregion
        
        #region Parameter LicenseType
        /// <summary>
        /// <para>
        /// <para>The license type to be used for the Amazon Machine Image (AMI) after importing.</para><para><b>Note:</b> You may only use BYOL if you have existing licenses with rights to use
        /// these licenses in a third party cloud like AWS. For more information, see <a href="http://docs.aws.amazon.com/vm-import/latest/userguide/vmimport-image-import.html#prerequisites-image">Prerequisites</a>
        /// in the VM Import/Export User Guide.</para><para>Valid values: <code>AWS</code> | <code>BYOL</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LicenseType { get; set; }
        #endregion
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The operating system of the virtual machine.</para><para>Valid values: <code>Windows</code> | <code>Linux</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Platform { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the role to use when not using the default role, 'vmimport'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter ClientData_UploadEnd
        /// <summary>
        /// <para>
        /// <para>The time that the disk upload ends.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ClientData_UploadEnd { get; set; }
        #endregion
        
        #region Parameter ClientData_UploadSize
        /// <summary>
        /// <para>
        /// <para>The size of the uploaded disk image, in GiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double ClientData_UploadSize { get; set; }
        #endregion
        
        #region Parameter ClientData_UploadStart
        /// <summary>
        /// <para>
        /// <para>The time that the disk upload starts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ClientData_UploadStart { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RoleName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-EC2Image (ImportImage)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Architecture = this.Architecture;
            context.ClientData_Comment = this.ClientData_Comment;
            if (ParameterWasBound("ClientData_UploadEnd"))
                context.ClientData_UploadEnd = this.ClientData_UploadEnd;
            if (ParameterWasBound("ClientData_UploadSize"))
                context.ClientData_UploadSize = this.ClientData_UploadSize;
            if (ParameterWasBound("ClientData_UploadStart"))
                context.ClientData_UploadStart = this.ClientData_UploadStart;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.DiskContainer != null)
            {
                context.DiskContainers = new List<Amazon.EC2.Model.ImageDiskContainer>(this.DiskContainer);
            }
            context.Hypervisor = this.Hypervisor;
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
            bool requestClientDataIsNull = true;
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
            System.DateTime? requestClientData_clientData_UploadEnd = null;
            if (cmdletContext.ClientData_UploadEnd != null)
            {
                requestClientData_clientData_UploadEnd = cmdletContext.ClientData_UploadEnd.Value;
            }
            if (requestClientData_clientData_UploadEnd != null)
            {
                request.ClientData.UploadEnd = requestClientData_clientData_UploadEnd.Value;
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
            System.DateTime? requestClientData_clientData_UploadStart = null;
            if (cmdletContext.ClientData_UploadStart != null)
            {
                requestClientData_clientData_UploadStart = cmdletContext.ClientData_UploadStart.Value;
            }
            if (requestClientData_clientData_UploadStart != null)
            {
                request.ClientData.UploadStart = requestClientData_clientData_UploadStart.Value;
                requestClientDataIsNull = false;
            }
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
            if (cmdletContext.DiskContainers != null)
            {
                request.DiskContainers = cmdletContext.DiskContainers;
            }
            if (cmdletContext.Hypervisor != null)
            {
                request.Hypervisor = cmdletContext.Hypervisor;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.EC2.Model.ImportImageResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ImportImageRequest request)
        {
            #if DESKTOP
            return client.ImportImage(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ImportImageAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Architecture { get; set; }
            public System.String ClientData_Comment { get; set; }
            public System.DateTime? ClientData_UploadEnd { get; set; }
            public System.Double? ClientData_UploadSize { get; set; }
            public System.DateTime? ClientData_UploadStart { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.EC2.Model.ImageDiskContainer> DiskContainers { get; set; }
            public System.String Hypervisor { get; set; }
            public System.String LicenseType { get; set; }
            public System.String Platform { get; set; }
            public System.String RoleName { get; set; }
        }
        
    }
}
