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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Defines the information that's necessary to populate an ID mapping table.
    /// </summary>
    [Cmdlet("Invoke", "CRSIdMappingTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service PopulateIdMappingTable API operation.", Operation = new[] {"PopulateIdMappingTable"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.PopulateIdMappingTableResponse))]
    [AWSCmdletOutput("System.String or Amazon.CleanRooms.Model.PopulateIdMappingTableResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CleanRooms.Model.PopulateIdMappingTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeCRSIdMappingTableCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdMappingTableIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the ID mapping table that you want to populate.</para>
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
        public System.String IdMappingTableIdentifier { get; set; }
        #endregion
        
        #region Parameter JobType
        /// <summary>
        /// <para>
        /// <para>The job type of the rule-based ID mapping job. Valid values include:</para><para><c>INCREMENTAL</c>: Processes only new or changed data since the last job run. This
        /// is the default job type if the ID mapping workflow was created in Entity Resolution
        /// with <c>incrementalRunConfig</c> specified.</para><para><c>BATCH</c>: Processes all data from the input source, regardless of previous job
        /// runs. This is the default job type if the ID mapping workflow was created in Entity
        /// Resolution but <c>incrementalRunConfig</c> wasn't specified.</para><para><c>DELETE_ONLY</c>: Processes only deletion requests from <c>BatchDeleteUniqueId</c>,
        /// which is set in Entity Resolution.</para><para>For more information about <c>incrementalRunConfig</c> and <c>BatchDeleteUniqueId</c>,
        /// see the <a href="https://docs.aws.amazon.com/entityresolution/latest/apireference/Welcome.html">Entity
        /// Resolution API Reference</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CleanRooms.JobType")]
        public Amazon.CleanRooms.JobType JobType { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the membership that contains the ID mapping table that you
        /// want to populate.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IdMappingJobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.PopulateIdMappingTableResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.PopulateIdMappingTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IdMappingJobId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IdMappingTableIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IdMappingTableIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IdMappingTableIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdMappingTableIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-CRSIdMappingTable (PopulateIdMappingTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.PopulateIdMappingTableResponse, InvokeCRSIdMappingTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IdMappingTableIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IdMappingTableIdentifier = this.IdMappingTableIdentifier;
            #if MODULAR
            if (this.IdMappingTableIdentifier == null && ParameterWasBound(nameof(this.IdMappingTableIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter IdMappingTableIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobType = this.JobType;
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CleanRooms.Model.PopulateIdMappingTableRequest();
            
            if (cmdletContext.IdMappingTableIdentifier != null)
            {
                request.IdMappingTableIdentifier = cmdletContext.IdMappingTableIdentifier;
            }
            if (cmdletContext.JobType != null)
            {
                request.JobType = cmdletContext.JobType;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
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
        
        private Amazon.CleanRooms.Model.PopulateIdMappingTableResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.PopulateIdMappingTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "PopulateIdMappingTable");
            try
            {
                #if DESKTOP
                return client.PopulateIdMappingTable(request);
                #elif CORECLR
                return client.PopulateIdMappingTableAsync(request).GetAwaiter().GetResult();
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
            public System.String IdMappingTableIdentifier { get; set; }
            public Amazon.CleanRooms.JobType JobType { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.Func<Amazon.CleanRooms.Model.PopulateIdMappingTableResponse, InvokeCRSIdMappingTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IdMappingJobId;
        }
        
    }
}
