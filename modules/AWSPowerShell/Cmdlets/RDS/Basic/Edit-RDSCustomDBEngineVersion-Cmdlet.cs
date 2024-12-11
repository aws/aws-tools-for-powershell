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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modifies the status of a custom engine version (CEV). You can find CEVs to modify
    /// by calling <c>DescribeDBEngineVersions</c>.
    /// 
    ///  <note><para>
    /// The MediaImport service that imports files from Amazon S3 to create CEVs isn't integrated
    /// with Amazon Web Services CloudTrail. If you turn on data logging for Amazon RDS in
    /// CloudTrail, calls to the <c>ModifyCustomDbEngineVersion</c> event aren't logged. However,
    /// you might see calls from the API gateway that accesses your Amazon S3 bucket. These
    /// calls originate from the MediaImport service for the <c>ModifyCustomDbEngineVersion</c>
    /// event.
    /// </para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/custom-cev.html#custom-cev.modify">Modifying
    /// CEV status</a> in the <i>Amazon RDS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RDSCustomDBEngineVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.ModifyCustomDBEngineVersionResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyCustomDBEngineVersion API operation.", Operation = new[] {"ModifyCustomDBEngineVersion"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyCustomDBEngineVersionResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.ModifyCustomDBEngineVersionResponse",
        "This cmdlet returns an Amazon.RDS.Model.ModifyCustomDBEngineVersionResponse object containing multiple properties."
    )]
    public partial class EditRDSCustomDBEngineVersionCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of your CEV.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine. RDS Custom for Oracle supports the following values:</para><ul><li><para><c>custom-oracle-ee</c></para></li><li><para><c>custom-oracle-ee-cdb</c></para></li><li><para><c>custom-oracle-se2</c></para></li><li><para><c>custom-oracle-se2-cdb</c></para></li></ul>
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
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The custom engine version (CEV) that you want to modify. This option is required for
        /// RDS Custom for Oracle, but optional for Amazon RDS. The combination of <c>Engine</c>
        /// and <c>EngineVersion</c> is unique per customer per Amazon Web Services Region.</para>
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
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The availability status to be assigned to the CEV. Valid values are as follows:</para><dl><dt>available</dt><dd><para>You can use this CEV to create a new RDS Custom DB instance.</para></dd><dt>inactive</dt><dd><para>You can create a new RDS Custom instance by restoring a DB snapshot with this CEV.
        /// You can't patch or create new instances with this CEV.</para></dd></dl><para>You can change any status to any status. A typical reason to change status is to prevent
        /// the accidental use of a CEV, or to make a deprecated CEV eligible for use again. For
        /// example, you might change the status of your CEV from <c>available</c> to <c>inactive</c>,
        /// and from <c>inactive</c> back to <c>available</c>. To change the availability status
        /// of the CEV, it must not currently be in use by an RDS Custom instance, snapshot, or
        /// automated backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.CustomEngineVersionStatus")]
        public Amazon.RDS.CustomEngineVersionStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyCustomDBEngineVersionResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyCustomDBEngineVersionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EngineVersion), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSCustomDBEngineVersion (ModifyCustomDBEngineVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyCustomDBEngineVersionResponse, EditRDSCustomDBEngineVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngineVersion = this.EngineVersion;
            #if MODULAR
            if (this.EngineVersion == null && ParameterWasBound(nameof(this.EngineVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter EngineVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            
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
            var request = new Amazon.RDS.Model.ModifyCustomDBEngineVersionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.RDS.Model.ModifyCustomDBEngineVersionResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyCustomDBEngineVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyCustomDBEngineVersion");
            try
            {
                #if DESKTOP
                return client.ModifyCustomDBEngineVersion(request);
                #elif CORECLR
                return client.ModifyCustomDBEngineVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public Amazon.RDS.CustomEngineVersionStatus Status { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyCustomDBEngineVersionResponse, EditRDSCustomDBEngineVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
