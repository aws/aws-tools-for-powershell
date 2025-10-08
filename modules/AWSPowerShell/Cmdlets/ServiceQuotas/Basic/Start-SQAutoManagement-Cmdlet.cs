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
using Amazon.ServiceQuotas;
using Amazon.ServiceQuotas.Model;

namespace Amazon.PowerShell.Cmdlets.SQ
{
    /// <summary>
    /// Starts <a href="https://docs.aws.amazon.com/servicequotas/latest/userguide/automatic-management.html">Service
    /// Quotas Automatic Management</a> for an Amazon Web Services account, including notification
    /// preferences and excluded quotas configurations. Automatic Management monitors your
    /// Service Quotas utilization and notifies you before you run out of your allocated quotas.
    /// </summary>
    [Cmdlet("Start", "SQAutoManagement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Service Quotas StartAutoManagement API operation.", Operation = new[] {"StartAutoManagement"}, SelectReturnType = typeof(Amazon.ServiceQuotas.Model.StartAutoManagementResponse))]
    [AWSCmdletOutput("None or Amazon.ServiceQuotas.Model.StartAutoManagementResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ServiceQuotas.Model.StartAutoManagementResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartSQAutoManagementCmdlet : AmazonServiceQuotasClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExclusionList
        /// <summary>
        /// <para>
        /// <para>List of Amazon Web Services services excluded from Automatic Management. You won't
        /// be notified of Service Quotas utilization for Amazon Web Services services added to
        /// the Automatic Management exclusion list. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ExclusionList { get; set; }
        #endregion
        
        #region Parameter NotificationArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/notifications/latest/userguide/resource-level-permissions.html#rlp-table">User
        /// Notifications</a> Amazon Resource Name (ARN) for Automatic Management notifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationArn { get; set; }
        #endregion
        
        #region Parameter OptInLevel
        /// <summary>
        /// <para>
        /// <para>Sets the opt-in level for Automatic Management. Only Amazon Web Services account level
        /// is supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ServiceQuotas.OptInLevel")]
        public Amazon.ServiceQuotas.OptInLevel OptInLevel { get; set; }
        #endregion
        
        #region Parameter OptInType
        /// <summary>
        /// <para>
        /// <para>Sets the opt-in type for Automatic Management. There are two modes: Notify only and
        /// Notify and Auto-Adjust. Currently, only NotifyOnly is available.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ServiceQuotas.OptInType")]
        public Amazon.ServiceQuotas.OptInType OptInType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceQuotas.Model.StartAutoManagementResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NotificationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SQAutoManagement (StartAutoManagement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceQuotas.Model.StartAutoManagementResponse, StartSQAutoManagementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ExclusionList != null)
            {
                context.ExclusionList = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.ExclusionList.Keys)
                {
                    object hashValue = this.ExclusionList[hashKey];
                    if (hashValue == null)
                    {
                        context.ExclusionList.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.ExclusionList.Add((String)hashKey, valueSet);
                }
            }
            context.NotificationArn = this.NotificationArn;
            context.OptInLevel = this.OptInLevel;
            #if MODULAR
            if (this.OptInLevel == null && ParameterWasBound(nameof(this.OptInLevel)))
            {
                WriteWarning("You are passing $null as a value for parameter OptInLevel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OptInType = this.OptInType;
            #if MODULAR
            if (this.OptInType == null && ParameterWasBound(nameof(this.OptInType)))
            {
                WriteWarning("You are passing $null as a value for parameter OptInType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServiceQuotas.Model.StartAutoManagementRequest();
            
            if (cmdletContext.ExclusionList != null)
            {
                request.ExclusionList = cmdletContext.ExclusionList;
            }
            if (cmdletContext.NotificationArn != null)
            {
                request.NotificationArn = cmdletContext.NotificationArn;
            }
            if (cmdletContext.OptInLevel != null)
            {
                request.OptInLevel = cmdletContext.OptInLevel;
            }
            if (cmdletContext.OptInType != null)
            {
                request.OptInType = cmdletContext.OptInType;
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
        
        private Amazon.ServiceQuotas.Model.StartAutoManagementResponse CallAWSServiceOperation(IAmazonServiceQuotas client, Amazon.ServiceQuotas.Model.StartAutoManagementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Quotas", "StartAutoManagement");
            try
            {
                #if DESKTOP
                return client.StartAutoManagement(request);
                #elif CORECLR
                return client.StartAutoManagementAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, List<System.String>> ExclusionList { get; set; }
            public System.String NotificationArn { get; set; }
            public Amazon.ServiceQuotas.OptInLevel OptInLevel { get; set; }
            public Amazon.ServiceQuotas.OptInType OptInType { get; set; }
            public System.Func<Amazon.ServiceQuotas.Model.StartAutoManagementResponse, StartSQAutoManagementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
