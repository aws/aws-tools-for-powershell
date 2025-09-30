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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a new option group. You can create up to 20 option groups.
    /// 
    ///  
    /// <para>
    /// This command doesn't apply to RDS Custom.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RDSOptionGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.OptionGroup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateOptionGroup API operation.", Operation = new[] {"CreateOptionGroup"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateOptionGroupResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.OptionGroup or Amazon.RDS.Model.CreateOptionGroupResponse",
        "This cmdlet returns an Amazon.RDS.Model.OptionGroup object.",
        "The service call response (type Amazon.RDS.Model.CreateOptionGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRDSOptionGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EngineName
        /// <summary>
        /// <para>
        /// <para>The name of the engine to associate this option group with.</para><para>Valid Values:</para><ul><li><para><c>db2-ae</c></para></li><li><para><c>db2-se</c></para></li><li><para><c>mariadb</c></para></li><li><para><c>mysql</c></para></li><li><para><c>oracle-ee</c></para></li><li><para><c>oracle-ee-cdb</c></para></li><li><para><c>oracle-se2</c></para></li><li><para><c>oracle-se2-cdb</c></para></li><li><para><c>postgres</c></para></li><li><para><c>sqlserver-ee</c></para></li><li><para><c>sqlserver-se</c></para></li><li><para><c>sqlserver-ex</c></para></li><li><para><c>sqlserver-web</c></para></li></ul>
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
        public System.String EngineName { get; set; }
        #endregion
        
        #region Parameter MajorEngineVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the major version of the engine that this option group should be associated
        /// with.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MajorEngineVersion { get; set; }
        #endregion
        
        #region Parameter OptionGroupDescription
        /// <summary>
        /// <para>
        /// <para>The description of the option group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String OptionGroupDescription { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the option group to be created.</para><para>Constraints:</para><ul><li><para>Must be 1 to 255 letters, numbers, or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul><para>Example: <c>myoptiongroup</c></para>
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
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the option group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OptionGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateOptionGroupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateOptionGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OptionGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OptionGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OptionGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OptionGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OptionGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSOptionGroup (CreateOptionGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateOptionGroupResponse, NewRDSOptionGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OptionGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EngineName = this.EngineName;
            #if MODULAR
            if (this.EngineName == null && ParameterWasBound(nameof(this.EngineName)))
            {
                WriteWarning("You are passing $null as a value for parameter EngineName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MajorEngineVersion = this.MajorEngineVersion;
            #if MODULAR
            if (this.MajorEngineVersion == null && ParameterWasBound(nameof(this.MajorEngineVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter MajorEngineVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OptionGroupDescription = this.OptionGroupDescription;
            #if MODULAR
            if (this.OptionGroupDescription == null && ParameterWasBound(nameof(this.OptionGroupDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter OptionGroupDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OptionGroupName = this.OptionGroupName;
            #if MODULAR
            if (this.OptionGroupName == null && ParameterWasBound(nameof(this.OptionGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter OptionGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
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
            var request = new Amazon.RDS.Model.CreateOptionGroupRequest();
            
            if (cmdletContext.EngineName != null)
            {
                request.EngineName = cmdletContext.EngineName;
            }
            if (cmdletContext.MajorEngineVersion != null)
            {
                request.MajorEngineVersion = cmdletContext.MajorEngineVersion;
            }
            if (cmdletContext.OptionGroupDescription != null)
            {
                request.OptionGroupDescription = cmdletContext.OptionGroupDescription;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
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
        
        private Amazon.RDS.Model.CreateOptionGroupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateOptionGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateOptionGroup");
            try
            {
                #if DESKTOP
                return client.CreateOptionGroup(request);
                #elif CORECLR
                return client.CreateOptionGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String EngineName { get; set; }
            public System.String MajorEngineVersion { get; set; }
            public System.String OptionGroupDescription { get; set; }
            public System.String OptionGroupName { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.RDS.Model.CreateOptionGroupResponse, NewRDSOptionGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OptionGroup;
        }
        
    }
}
