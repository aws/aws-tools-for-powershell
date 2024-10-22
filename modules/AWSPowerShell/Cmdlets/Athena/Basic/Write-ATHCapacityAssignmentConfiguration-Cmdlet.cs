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
using Amazon.Athena;
using Amazon.Athena.Model;

namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Puts a new capacity assignment configuration for a specified capacity reservation.
    /// If a capacity assignment configuration already exists for the capacity reservation,
    /// replaces the existing capacity assignment configuration.
    /// </summary>
    [Cmdlet("Write", "ATHCapacityAssignmentConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Athena PutCapacityAssignmentConfiguration API operation.", Operation = new[] {"PutCapacityAssignmentConfiguration"}, SelectReturnType = typeof(Amazon.Athena.Model.PutCapacityAssignmentConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.Athena.Model.PutCapacityAssignmentConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Athena.Model.PutCapacityAssignmentConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteATHCapacityAssignmentConfigurationCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityAssignment
        /// <summary>
        /// <para>
        /// <para>The list of assignments for the capacity assignment configuration.</para>
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
        [Alias("CapacityAssignments")]
        public Amazon.Athena.Model.CapacityAssignment[] CapacityAssignment { get; set; }
        #endregion
        
        #region Parameter CapacityReservationName
        /// <summary>
        /// <para>
        /// <para>The name of the capacity reservation to put a capacity assignment configuration for.</para>
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
        public System.String CapacityReservationName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.PutCapacityAssignmentConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapacityReservationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ATHCapacityAssignmentConfiguration (PutCapacityAssignmentConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.PutCapacityAssignmentConfigurationResponse, WriteATHCapacityAssignmentConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CapacityAssignment != null)
            {
                context.CapacityAssignment = new List<Amazon.Athena.Model.CapacityAssignment>(this.CapacityAssignment);
            }
            #if MODULAR
            if (this.CapacityAssignment == null && ParameterWasBound(nameof(this.CapacityAssignment)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityAssignment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CapacityReservationName = this.CapacityReservationName;
            #if MODULAR
            if (this.CapacityReservationName == null && ParameterWasBound(nameof(this.CapacityReservationName)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityReservationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Athena.Model.PutCapacityAssignmentConfigurationRequest();
            
            if (cmdletContext.CapacityAssignment != null)
            {
                request.CapacityAssignments = cmdletContext.CapacityAssignment;
            }
            if (cmdletContext.CapacityReservationName != null)
            {
                request.CapacityReservationName = cmdletContext.CapacityReservationName;
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
        
        private Amazon.Athena.Model.PutCapacityAssignmentConfigurationResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.PutCapacityAssignmentConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "PutCapacityAssignmentConfiguration");
            try
            {
                #if DESKTOP
                return client.PutCapacityAssignmentConfiguration(request);
                #elif CORECLR
                return client.PutCapacityAssignmentConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Athena.Model.CapacityAssignment> CapacityAssignment { get; set; }
            public System.String CapacityReservationName { get; set; }
            public System.Func<Amazon.Athena.Model.PutCapacityAssignmentConfigurationResponse, WriteATHCapacityAssignmentConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
