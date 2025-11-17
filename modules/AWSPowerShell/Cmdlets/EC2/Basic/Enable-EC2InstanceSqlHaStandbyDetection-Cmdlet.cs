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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Enable Amazon EC2 instances running in an SQL Server High Availability cluster for
    /// SQL Server High Availability instance standby detection monitoring. Once enabled,
    /// Amazon Web Services monitors the metadata for the instances to determine whether they
    /// are active or standby nodes in the SQL Server High Availability cluster. If the instances
    /// are determined to be standby failover nodes, Amazon Web Services automatically applies
    /// SQL Server licensing fee waiver for those instances.
    /// 
    ///  
    /// <para>
    /// To register an instance, it must be running a Windows SQL Server license-included
    /// AMI and have the Amazon Web Services Systems Manager agent installed and running.
    /// Only Windows Server 2019 and later and SQL Server (Standard and Enterprise editions)
    /// 2017 and later are supported. For more information, see <a href="https://docs.aws.amazon.com/sql-server-ec2/latest/userguide/prerequisites-and-requirements.html">
    /// Prerequisites for using SQL Server High Availability instance standby detection</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "EC2InstanceSqlHaStandbyDetection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.RegisteredInstance")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) EnableInstanceSqlHaStandbyDetections API operation.", Operation = new[] {"EnableInstanceSqlHaStandbyDetections"}, SelectReturnType = typeof(Amazon.EC2.Model.EnableInstanceSqlHaStandbyDetectionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.RegisteredInstance or Amazon.EC2.Model.EnableInstanceSqlHaStandbyDetectionsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.RegisteredInstance objects.",
        "The service call response (type Amazon.EC2.Model.EnableInstanceSqlHaStandbyDetectionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableEC2InstanceSqlHaStandbyDetectionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the instances to enable for SQL Server High Availability standby detection
        /// monitoring.</para>
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
        [Alias("InstanceIds")]
        public object[] InstanceId { get; set; }
        #endregion
        
        #region Parameter SqlServerCredential
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret containing the SQL Server access credentials.
        /// The specified secret must contain valid SQL Server credentials for the specified instances.
        /// If not specified, deafult local user credentials will be used by the Amazon Web Services
        /// Systems Manager agent. To enable instances with different credentials, you must make
        /// separate requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SqlServerCredentials")]
        public System.String SqlServerCredential { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Instances'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.EnableInstanceSqlHaStandbyDetectionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.EnableInstanceSqlHaStandbyDetectionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Instances";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SqlServerCredential parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SqlServerCredential' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SqlServerCredential' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-EC2InstanceSqlHaStandbyDetection (EnableInstanceSqlHaStandbyDetections)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.EnableInstanceSqlHaStandbyDetectionsResponse, EnableEC2InstanceSqlHaStandbyDetectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SqlServerCredential;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.InstanceId != null)
            {
                context.InstanceId = AmazonEC2Helper.InstanceParamToIDs(this.InstanceId);
            }
            
            context.SqlServerCredential = this.SqlServerCredential;
            
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
            var request = new Amazon.EC2.Model.EnableInstanceSqlHaStandbyDetectionsRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceIds = cmdletContext.InstanceId;
            }
            if (cmdletContext.SqlServerCredential != null)
            {
                request.SqlServerCredentials = cmdletContext.SqlServerCredential;
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
        
        private Amazon.EC2.Model.EnableInstanceSqlHaStandbyDetectionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.EnableInstanceSqlHaStandbyDetectionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "EnableInstanceSqlHaStandbyDetections");
            try
            {
                #if DESKTOP
                return client.EnableInstanceSqlHaStandbyDetections(request);
                #elif CORECLR
                return client.EnableInstanceSqlHaStandbyDetectionsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> InstanceId { get; set; }
            public System.String SqlServerCredential { get; set; }
            public System.Func<Amazon.EC2.Model.EnableInstanceSqlHaStandbyDetectionsResponse, EnableEC2InstanceSqlHaStandbyDetectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Instances;
        }
        
    }
}
