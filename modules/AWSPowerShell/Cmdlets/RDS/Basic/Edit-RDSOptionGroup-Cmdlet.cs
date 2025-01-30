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
    /// Modifies an existing option group.
    /// </summary>
    [Cmdlet("Edit", "RDSOptionGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.OptionGroup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyOptionGroup API operation.", Operation = new[] {"ModifyOptionGroup"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyOptionGroupResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.OptionGroup or Amazon.RDS.Model.ModifyOptionGroupResponse",
        "This cmdlet returns an Amazon.RDS.Model.OptionGroup object.",
        "The service call response (type Amazon.RDS.Model.ModifyOptionGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSOptionGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>Specifies whether to apply the change immediately or during the next maintenance window
        /// for each instance associated with the option group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the option group to be modified.</para><para>Permanent options, such as the TDE option for Oracle Advanced Security TDE, can't
        /// be removed from an option group, and that option group can't be removed from a DB
        /// instance once it is associated with a DB instance</para>
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
        
        #region Parameter OptionsToInclude
        /// <summary>
        /// <para>
        /// <para>Options in this list are added to the option group or, if already present, the specified
        /// configuration is used to update the existing configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.RDS.Model.OptionConfiguration[] OptionsToInclude { get; set; }
        #endregion
        
        #region Parameter OptionsToRemove
        /// <summary>
        /// <para>
        /// <para>Options in this list are removed from the option group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] OptionsToRemove { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OptionGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyOptionGroupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyOptionGroupResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSOptionGroup (ModifyOptionGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyOptionGroupResponse, EditRDSOptionGroupCmdlet>(Select) ??
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
            context.ApplyImmediately = this.ApplyImmediately;
            context.OptionGroupName = this.OptionGroupName;
            #if MODULAR
            if (this.OptionGroupName == null && ParameterWasBound(nameof(this.OptionGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter OptionGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OptionsToInclude != null)
            {
                context.OptionsToInclude = new List<Amazon.RDS.Model.OptionConfiguration>(this.OptionsToInclude);
            }
            if (this.OptionsToRemove != null)
            {
                context.OptionsToRemove = new List<System.String>(this.OptionsToRemove);
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
            var request = new Amazon.RDS.Model.ModifyOptionGroupRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.OptionsToInclude != null)
            {
                request.OptionsToInclude = cmdletContext.OptionsToInclude;
            }
            if (cmdletContext.OptionsToRemove != null)
            {
                request.OptionsToRemove = cmdletContext.OptionsToRemove;
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
        
        private Amazon.RDS.Model.ModifyOptionGroupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyOptionGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyOptionGroup");
            try
            {
                #if DESKTOP
                return client.ModifyOptionGroup(request);
                #elif CORECLR
                return client.ModifyOptionGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ApplyImmediately { get; set; }
            public System.String OptionGroupName { get; set; }
            public List<Amazon.RDS.Model.OptionConfiguration> OptionsToInclude { get; set; }
            public List<System.String> OptionsToRemove { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyOptionGroupResponse, EditRDSOptionGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OptionGroup;
        }
        
    }
}
