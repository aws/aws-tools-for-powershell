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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Updates the parameters of a parameter group. You can modify up to 20 parameters in
    /// a single request by submitting a list parameter name and value pairs.
    /// </summary>
    [Cmdlet("Update", "MDBParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MemoryDB.Model.ParameterGroup")]
    [AWSCmdlet("Calls the Amazon MemoryDB UpdateParameterGroup API operation.", Operation = new[] {"UpdateParameterGroup"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.UpdateParameterGroupResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.ParameterGroup or Amazon.MemoryDB.Model.UpdateParameterGroupResponse",
        "This cmdlet returns an Amazon.MemoryDB.Model.ParameterGroup object.",
        "The service call response (type Amazon.MemoryDB.Model.UpdateParameterGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateMDBParameterGroupCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the parameter group to update.</para>
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
        
        #region Parameter ParameterNameValue
        /// <summary>
        /// <para>
        /// <para>An array of parameter names and values for the parameter update. You must supply at
        /// least one parameter name and value; subsequent arguments are optional. A maximum of
        /// 20 parameters may be updated per request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ParameterNameValues")]
        public Amazon.MemoryDB.Model.ParameterNameValue[] ParameterNameValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ParameterGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.UpdateParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.UpdateParameterGroupResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MDBParameterGroup (UpdateParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.UpdateParameterGroupResponse, UpdateMDBParameterGroupCmdlet>(Select) ??
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
            context.ParameterGroupName = this.ParameterGroupName;
            #if MODULAR
            if (this.ParameterGroupName == null && ParameterWasBound(nameof(this.ParameterGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ParameterGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ParameterNameValue != null)
            {
                context.ParameterNameValue = new List<Amazon.MemoryDB.Model.ParameterNameValue>(this.ParameterNameValue);
            }
            #if MODULAR
            if (this.ParameterNameValue == null && ParameterWasBound(nameof(this.ParameterNameValue)))
            {
                WriteWarning("You are passing $null as a value for parameter ParameterNameValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MemoryDB.Model.UpdateParameterGroupRequest();
            
            if (cmdletContext.ParameterGroupName != null)
            {
                request.ParameterGroupName = cmdletContext.ParameterGroupName;
            }
            if (cmdletContext.ParameterNameValue != null)
            {
                request.ParameterNameValues = cmdletContext.ParameterNameValue;
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
        
        private Amazon.MemoryDB.Model.UpdateParameterGroupResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.UpdateParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "UpdateParameterGroup");
            try
            {
                #if DESKTOP
                return client.UpdateParameterGroup(request);
                #elif CORECLR
                return client.UpdateParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String ParameterGroupName { get; set; }
            public List<Amazon.MemoryDB.Model.ParameterNameValue> ParameterNameValue { get; set; }
            public System.Func<Amazon.MemoryDB.Model.UpdateParameterGroupResponse, UpdateMDBParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ParameterGroup;
        }
        
    }
}
