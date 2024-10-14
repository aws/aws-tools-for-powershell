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
    /// Copies the specified DB cluster parameter group.
    /// 
    ///  <note><para>
    /// You can't copy a default DB cluster parameter group. Instead, create a new custom
    /// DB cluster parameter group, which copies the default parameters and values for the
    /// specified DB cluster parameter group family.
    /// </para></note>
    /// </summary>
    [Cmdlet("Copy", "RDSDBClusterParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBClusterParameterGroup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CopyDBClusterParameterGroup API operation.", Operation = new[] {"CopyDBClusterParameterGroup"}, SelectReturnType = typeof(Amazon.RDS.Model.CopyDBClusterParameterGroupResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBClusterParameterGroup or Amazon.RDS.Model.CopyDBClusterParameterGroupResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBClusterParameterGroup object.",
        "The service call response (type Amazon.RDS.Model.CopyDBClusterParameterGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyRDSDBClusterParameterGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SourceDBClusterParameterGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier or Amazon Resource Name (ARN) for the source DB cluster parameter group.
        /// For information about creating an ARN, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_Tagging.ARN.html#USER_Tagging.ARN.Constructing">
        /// Constructing an ARN for Amazon RDS</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Constraints:</para><ul><li><para>Must specify a valid DB cluster parameter group.</para></li></ul>
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
        public System.String SourceDBClusterParameterGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDBClusterParameterGroupDescription
        /// <summary>
        /// <para>
        /// <para>A description for the copied DB cluster parameter group.</para>
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
        public System.String TargetDBClusterParameterGroupDescription { get; set; }
        #endregion
        
        #region Parameter TargetDBClusterParameterGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the copied DB cluster parameter group.</para><para>Constraints:</para><ul><li><para>Can't be null, empty, or blank</para></li><li><para>Must contain from 1 to 255 letters, numbers, or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul><para>Example: <c>my-cluster-param-group1</c></para>
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
        public System.String TargetDBClusterParameterGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterParameterGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CopyDBClusterParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CopyDBClusterParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterParameterGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceDBClusterParameterGroupIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceDBClusterParameterGroupIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceDBClusterParameterGroupIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceDBClusterParameterGroupIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-RDSDBClusterParameterGroup (CopyDBClusterParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CopyDBClusterParameterGroupResponse, CopyRDSDBClusterParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceDBClusterParameterGroupIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SourceDBClusterParameterGroupIdentifier = this.SourceDBClusterParameterGroupIdentifier;
            #if MODULAR
            if (this.SourceDBClusterParameterGroupIdentifier == null && ParameterWasBound(nameof(this.SourceDBClusterParameterGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDBClusterParameterGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetDBClusterParameterGroupDescription = this.TargetDBClusterParameterGroupDescription;
            #if MODULAR
            if (this.TargetDBClusterParameterGroupDescription == null && ParameterWasBound(nameof(this.TargetDBClusterParameterGroupDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDBClusterParameterGroupDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetDBClusterParameterGroupIdentifier = this.TargetDBClusterParameterGroupIdentifier;
            #if MODULAR
            if (this.TargetDBClusterParameterGroupIdentifier == null && ParameterWasBound(nameof(this.TargetDBClusterParameterGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDBClusterParameterGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.CopyDBClusterParameterGroupRequest();
            
            if (cmdletContext.SourceDBClusterParameterGroupIdentifier != null)
            {
                request.SourceDBClusterParameterGroupIdentifier = cmdletContext.SourceDBClusterParameterGroupIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetDBClusterParameterGroupDescription != null)
            {
                request.TargetDBClusterParameterGroupDescription = cmdletContext.TargetDBClusterParameterGroupDescription;
            }
            if (cmdletContext.TargetDBClusterParameterGroupIdentifier != null)
            {
                request.TargetDBClusterParameterGroupIdentifier = cmdletContext.TargetDBClusterParameterGroupIdentifier;
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
        
        private Amazon.RDS.Model.CopyDBClusterParameterGroupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CopyDBClusterParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CopyDBClusterParameterGroup");
            try
            {
                #if DESKTOP
                return client.CopyDBClusterParameterGroup(request);
                #elif CORECLR
                return client.CopyDBClusterParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String SourceDBClusterParameterGroupIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.String TargetDBClusterParameterGroupDescription { get; set; }
            public System.String TargetDBClusterParameterGroupIdentifier { get; set; }
            public System.Func<Amazon.RDS.Model.CopyDBClusterParameterGroupResponse, CopyRDSDBClusterParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterParameterGroup;
        }
        
    }
}
