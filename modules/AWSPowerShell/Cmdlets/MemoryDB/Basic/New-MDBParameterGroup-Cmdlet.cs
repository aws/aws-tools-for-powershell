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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Creates a new MemoryDB parameter group. A parameter group is a collection of parameters
    /// and their values that are applied to all of the nodes in any cluster. For more information,
    /// see <a href="https://docs.aws.amazon.com/MemoryDB/latest/devguide/parametergroups.html">Configuring
    /// engine parameters using parameter groups</a>.
    /// </summary>
    [Cmdlet("New", "MDBParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MemoryDB.Model.ParameterGroup")]
    [AWSCmdlet("Calls the Amazon MemoryDB CreateParameterGroup API operation.", Operation = new[] {"CreateParameterGroup"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.CreateParameterGroupResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.ParameterGroup or Amazon.MemoryDB.Model.CreateParameterGroupResponse",
        "This cmdlet returns an Amazon.MemoryDB.Model.ParameterGroup object.",
        "The service call response (type Amazon.MemoryDB.Model.CreateParameterGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMDBParameterGroupCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Family
        /// <summary>
        /// <para>
        /// <para>The name of the parameter group family that the parameter group can be used with.</para>
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
        public System.String Family { get; set; }
        #endregion
        
        #region Parameter ParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the parameter group.</para>
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
        public System.String ParameterGroupName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to be added to this resource. A tag is a key-value pair. A tag key
        /// must be accompanied by a tag value, although null is accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.MemoryDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ParameterGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.CreateParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.CreateParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ParameterGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ParameterGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ParameterGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ParameterGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ParameterGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MDBParameterGroup (CreateParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.CreateParameterGroupResponse, NewMDBParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ParameterGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.Family = this.Family;
            #if MODULAR
            if (this.Family == null && ParameterWasBound(nameof(this.Family)))
            {
                WriteWarning("You are passing $null as a value for parameter Family which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParameterGroupName = this.ParameterGroupName;
            #if MODULAR
            if (this.ParameterGroupName == null && ParameterWasBound(nameof(this.ParameterGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ParameterGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.MemoryDB.Model.Tag>(this.Tag);
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
            var request = new Amazon.MemoryDB.Model.CreateParameterGroupRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Family != null)
            {
                request.Family = cmdletContext.Family;
            }
            if (cmdletContext.ParameterGroupName != null)
            {
                request.ParameterGroupName = cmdletContext.ParameterGroupName;
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
        
        private Amazon.MemoryDB.Model.CreateParameterGroupResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.CreateParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "CreateParameterGroup");
            try
            {
                #if DESKTOP
                return client.CreateParameterGroup(request);
                #elif CORECLR
                return client.CreateParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Family { get; set; }
            public System.String ParameterGroupName { get; set; }
            public List<Amazon.MemoryDB.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.MemoryDB.Model.CreateParameterGroupResponse, NewMDBParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ParameterGroup;
        }
        
    }
}
