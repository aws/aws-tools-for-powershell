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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Modifies the specified WorkSpace properties. For important information about how to
    /// modify the size of the root and user volumes, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/modify-workspaces.html">
    /// Modify a WorkSpace</a>. 
    /// 
    ///  <note><para>
    /// The <c>MANUAL</c> running mode value is only supported by Amazon WorkSpaces Core.
    /// Contact your account team to be allow-listed to use this value. For more information,
    /// see <a href="http://aws.amazon.com/workspaces/core/">Amazon WorkSpaces Core</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "WKSWorkspaceProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ModifyWorkspaceProperties API operation.", Operation = new[] {"ModifyWorkspaceProperties"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesResponse))]
    [AWSCmdletOutput("None or Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditWKSWorkspacePropertyCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter WorkspaceProperties_ComputeTypeName
        /// <summary>
        /// <para>
        /// <para>The compute type. For more information, see <a href="http://aws.amazon.com/workspaces/details/#Amazon_WorkSpaces_Bundles">Amazon
        /// WorkSpaces Bundles</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.Compute")]
        public Amazon.WorkSpaces.Compute WorkspaceProperties_ComputeTypeName { get; set; }
        #endregion
        
        #region Parameter DataReplication
        /// <summary>
        /// <para>
        /// <para>Indicates the data replication status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.DataReplication")]
        public Amazon.WorkSpaces.DataReplication DataReplication { get; set; }
        #endregion
        
        #region Parameter WorkspaceProperties_OperatingSystemName
        /// <summary>
        /// <para>
        /// <para>The name of the operating system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.OperatingSystemName")]
        public Amazon.WorkSpaces.OperatingSystemName WorkspaceProperties_OperatingSystemName { get; set; }
        #endregion
        
        #region Parameter WorkspaceProperties_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol. For more information, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/amazon-workspaces-protocols.html">
        /// Protocols for Amazon WorkSpaces</a>.</para><note><ul><li><para>Only available for WorkSpaces created with PCoIP bundles.</para></li><li><para>The <c>Protocols</c> property is case sensitive. Ensure you use <c>PCOIP</c> or <c>DCV</c>
        /// (formerly WSP).</para></li><li><para>Unavailable for Windows 7 WorkSpaces and WorkSpaces using GPU-based bundles (Graphics,
        /// GraphicsPro, Graphics.g4dn, and GraphicsPro.g4dn).</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceProperties_Protocols")]
        public System.String[] WorkspaceProperties_Protocol { get; set; }
        #endregion
        
        #region Parameter WorkspaceProperties_RootVolumeSizeGib
        /// <summary>
        /// <para>
        /// <para>The size of the root volume. For important information about how to modify the size
        /// of the root and user volumes, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/modify-workspaces.html">Modify
        /// a WorkSpace</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? WorkspaceProperties_RootVolumeSizeGib { get; set; }
        #endregion
        
        #region Parameter WorkspaceProperties_RunningMode
        /// <summary>
        /// <para>
        /// <para>The running mode. For more information, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/running-mode.html">Manage
        /// the WorkSpace Running Mode</a>.</para><note><para>The <c>MANUAL</c> value is only supported by Amazon WorkSpaces Core. Contact your
        /// account team to be allow-listed to use this value. For more information, see <a href="http://aws.amazon.com/workspaces/core/">Amazon
        /// WorkSpaces Core</a>.</para></note><para>Review your running mode to ensure you are using one that is optimal for your needs
        /// and budget. For more information on switching running modes, see <a href="http://aws.amazon.com/workspaces-family/workspaces/faqs/#:~:text=Can%20I%20switch%20between%20hourly%20and%20monthly%20billing%20on%20WorkSpaces%20Personal%3F">
        /// Can I switch between hourly and monthly billing?</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.RunningMode")]
        public Amazon.WorkSpaces.RunningMode WorkspaceProperties_RunningMode { get; set; }
        #endregion
        
        #region Parameter WorkspaceProperties_RunningModeAutoStopTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The time after a user logs off when WorkSpaces are automatically stopped. Configured
        /// in 60-minute intervals.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkspaceProperties_RunningModeAutoStopTimeoutInMinutes")]
        public System.Int32? WorkspaceProperties_RunningModeAutoStopTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter WorkspaceProperties_UserVolumeSizeGib
        /// <summary>
        /// <para>
        /// <para>The size of the user storage. For important information about how to modify the size
        /// of the root and user volumes, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/modify-workspaces.html">Modify
        /// a WorkSpace</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? WorkspaceProperties_UserVolumeSizeGib { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the WorkSpace.</para>
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
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkspaceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkspaceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkspaceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-WKSWorkspaceProperty (ModifyWorkspaceProperties)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesResponse, EditWKSWorkspacePropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkspaceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataReplication = this.DataReplication;
            context.WorkspaceId = this.WorkspaceId;
            #if MODULAR
            if (this.WorkspaceId == null && ParameterWasBound(nameof(this.WorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkspaceProperties_ComputeTypeName = this.WorkspaceProperties_ComputeTypeName;
            context.WorkspaceProperties_OperatingSystemName = this.WorkspaceProperties_OperatingSystemName;
            if (this.WorkspaceProperties_Protocol != null)
            {
                context.WorkspaceProperties_Protocol = new List<System.String>(this.WorkspaceProperties_Protocol);
            }
            context.WorkspaceProperties_RootVolumeSizeGib = this.WorkspaceProperties_RootVolumeSizeGib;
            context.WorkspaceProperties_RunningMode = this.WorkspaceProperties_RunningMode;
            context.WorkspaceProperties_RunningModeAutoStopTimeoutInMinute = this.WorkspaceProperties_RunningModeAutoStopTimeoutInMinute;
            context.WorkspaceProperties_UserVolumeSizeGib = this.WorkspaceProperties_UserVolumeSizeGib;
            
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
            var request = new Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesRequest();
            
            if (cmdletContext.DataReplication != null)
            {
                request.DataReplication = cmdletContext.DataReplication;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
            }
            
             // populate WorkspaceProperties
            var requestWorkspacePropertiesIsNull = true;
            request.WorkspaceProperties = new Amazon.WorkSpaces.Model.WorkspaceProperties();
            Amazon.WorkSpaces.Compute requestWorkspaceProperties_workspaceProperties_ComputeTypeName = null;
            if (cmdletContext.WorkspaceProperties_ComputeTypeName != null)
            {
                requestWorkspaceProperties_workspaceProperties_ComputeTypeName = cmdletContext.WorkspaceProperties_ComputeTypeName;
            }
            if (requestWorkspaceProperties_workspaceProperties_ComputeTypeName != null)
            {
                request.WorkspaceProperties.ComputeTypeName = requestWorkspaceProperties_workspaceProperties_ComputeTypeName;
                requestWorkspacePropertiesIsNull = false;
            }
            Amazon.WorkSpaces.OperatingSystemName requestWorkspaceProperties_workspaceProperties_OperatingSystemName = null;
            if (cmdletContext.WorkspaceProperties_OperatingSystemName != null)
            {
                requestWorkspaceProperties_workspaceProperties_OperatingSystemName = cmdletContext.WorkspaceProperties_OperatingSystemName;
            }
            if (requestWorkspaceProperties_workspaceProperties_OperatingSystemName != null)
            {
                request.WorkspaceProperties.OperatingSystemName = requestWorkspaceProperties_workspaceProperties_OperatingSystemName;
                requestWorkspacePropertiesIsNull = false;
            }
            List<System.String> requestWorkspaceProperties_workspaceProperties_Protocol = null;
            if (cmdletContext.WorkspaceProperties_Protocol != null)
            {
                requestWorkspaceProperties_workspaceProperties_Protocol = cmdletContext.WorkspaceProperties_Protocol;
            }
            if (requestWorkspaceProperties_workspaceProperties_Protocol != null)
            {
                request.WorkspaceProperties.Protocols = requestWorkspaceProperties_workspaceProperties_Protocol;
                requestWorkspacePropertiesIsNull = false;
            }
            System.Int32? requestWorkspaceProperties_workspaceProperties_RootVolumeSizeGib = null;
            if (cmdletContext.WorkspaceProperties_RootVolumeSizeGib != null)
            {
                requestWorkspaceProperties_workspaceProperties_RootVolumeSizeGib = cmdletContext.WorkspaceProperties_RootVolumeSizeGib.Value;
            }
            if (requestWorkspaceProperties_workspaceProperties_RootVolumeSizeGib != null)
            {
                request.WorkspaceProperties.RootVolumeSizeGib = requestWorkspaceProperties_workspaceProperties_RootVolumeSizeGib.Value;
                requestWorkspacePropertiesIsNull = false;
            }
            Amazon.WorkSpaces.RunningMode requestWorkspaceProperties_workspaceProperties_RunningMode = null;
            if (cmdletContext.WorkspaceProperties_RunningMode != null)
            {
                requestWorkspaceProperties_workspaceProperties_RunningMode = cmdletContext.WorkspaceProperties_RunningMode;
            }
            if (requestWorkspaceProperties_workspaceProperties_RunningMode != null)
            {
                request.WorkspaceProperties.RunningMode = requestWorkspaceProperties_workspaceProperties_RunningMode;
                requestWorkspacePropertiesIsNull = false;
            }
            System.Int32? requestWorkspaceProperties_workspaceProperties_RunningModeAutoStopTimeoutInMinute = null;
            if (cmdletContext.WorkspaceProperties_RunningModeAutoStopTimeoutInMinute != null)
            {
                requestWorkspaceProperties_workspaceProperties_RunningModeAutoStopTimeoutInMinute = cmdletContext.WorkspaceProperties_RunningModeAutoStopTimeoutInMinute.Value;
            }
            if (requestWorkspaceProperties_workspaceProperties_RunningModeAutoStopTimeoutInMinute != null)
            {
                request.WorkspaceProperties.RunningModeAutoStopTimeoutInMinutes = requestWorkspaceProperties_workspaceProperties_RunningModeAutoStopTimeoutInMinute.Value;
                requestWorkspacePropertiesIsNull = false;
            }
            System.Int32? requestWorkspaceProperties_workspaceProperties_UserVolumeSizeGib = null;
            if (cmdletContext.WorkspaceProperties_UserVolumeSizeGib != null)
            {
                requestWorkspaceProperties_workspaceProperties_UserVolumeSizeGib = cmdletContext.WorkspaceProperties_UserVolumeSizeGib.Value;
            }
            if (requestWorkspaceProperties_workspaceProperties_UserVolumeSizeGib != null)
            {
                request.WorkspaceProperties.UserVolumeSizeGib = requestWorkspaceProperties_workspaceProperties_UserVolumeSizeGib.Value;
                requestWorkspacePropertiesIsNull = false;
            }
             // determine if request.WorkspaceProperties should be set to null
            if (requestWorkspacePropertiesIsNull)
            {
                request.WorkspaceProperties = null;
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
        
        private Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ModifyWorkspaceProperties");
            try
            {
                #if DESKTOP
                return client.ModifyWorkspaceProperties(request);
                #elif CORECLR
                return client.ModifyWorkspacePropertiesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.WorkSpaces.DataReplication DataReplication { get; set; }
            public System.String WorkspaceId { get; set; }
            public Amazon.WorkSpaces.Compute WorkspaceProperties_ComputeTypeName { get; set; }
            public Amazon.WorkSpaces.OperatingSystemName WorkspaceProperties_OperatingSystemName { get; set; }
            public List<System.String> WorkspaceProperties_Protocol { get; set; }
            public System.Int32? WorkspaceProperties_RootVolumeSizeGib { get; set; }
            public Amazon.WorkSpaces.RunningMode WorkspaceProperties_RunningMode { get; set; }
            public System.Int32? WorkspaceProperties_RunningModeAutoStopTimeoutInMinute { get; set; }
            public System.Int32? WorkspaceProperties_UserVolumeSizeGib { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ModifyWorkspacePropertiesResponse, EditWKSWorkspacePropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
