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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Reloads the target database table with the source data. 
    /// 
    ///  
    /// <para>
    /// You can only use this operation with a task in the <c>RUNNING</c> state, otherwise
    /// the service will throw an <c>InvalidResourceStateFault</c> exception.
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "DMSTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Database Migration Service ReloadTables API operation.", Operation = new[] {"ReloadTables"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.ReloadTablesResponse))]
    [AWSCmdletOutput("System.String or Amazon.DatabaseMigrationService.Model.ReloadTablesResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.ReloadTablesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RestoreDMSTableCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReloadOption
        /// <summary>
        /// <para>
        /// <para>Options for reload. Specify <c>data-reload</c> to reload the data and re-validate
        /// it if validation is enabled. Specify <c>validate-only</c> to re-validate the table.
        /// This option applies only when validation is enabled for the task. </para><para>Valid values: data-reload, validate-only</para><para>Default value is data-reload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.ReloadOptionValue")]
        public Amazon.DatabaseMigrationService.ReloadOptionValue ReloadOption { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the replication task. </para>
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
        public System.String ReplicationTaskArn { get; set; }
        #endregion
        
        #region Parameter TablesToReload
        /// <summary>
        /// <para>
        /// <para>The name and schema of the table to be reloaded. </para>
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
        public Amazon.DatabaseMigrationService.Model.TableToReload[] TablesToReload { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationTaskArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.ReloadTablesResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.ReloadTablesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationTaskArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationTaskArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-DMSTable (ReloadTables)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.ReloadTablesResponse, RestoreDMSTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ReloadOption = this.ReloadOption;
            context.ReplicationTaskArn = this.ReplicationTaskArn;
            #if MODULAR
            if (this.ReplicationTaskArn == null && ParameterWasBound(nameof(this.ReplicationTaskArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationTaskArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TablesToReload != null)
            {
                context.TablesToReload = new List<Amazon.DatabaseMigrationService.Model.TableToReload>(this.TablesToReload);
            }
            #if MODULAR
            if (this.TablesToReload == null && ParameterWasBound(nameof(this.TablesToReload)))
            {
                WriteWarning("You are passing $null as a value for parameter TablesToReload which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DatabaseMigrationService.Model.ReloadTablesRequest();
            
            if (cmdletContext.ReloadOption != null)
            {
                request.ReloadOption = cmdletContext.ReloadOption;
            }
            if (cmdletContext.ReplicationTaskArn != null)
            {
                request.ReplicationTaskArn = cmdletContext.ReplicationTaskArn;
            }
            if (cmdletContext.TablesToReload != null)
            {
                request.TablesToReload = cmdletContext.TablesToReload;
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
        
        private Amazon.DatabaseMigrationService.Model.ReloadTablesResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.ReloadTablesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "ReloadTables");
            try
            {
                #if DESKTOP
                return client.ReloadTables(request);
                #elif CORECLR
                return client.ReloadTablesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DatabaseMigrationService.ReloadOptionValue ReloadOption { get; set; }
            public System.String ReplicationTaskArn { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.TableToReload> TablesToReload { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.ReloadTablesResponse, RestoreDMSTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationTaskArn;
        }
        
    }
}
