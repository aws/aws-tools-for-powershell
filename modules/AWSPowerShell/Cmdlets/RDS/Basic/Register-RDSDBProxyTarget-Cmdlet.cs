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
    /// <note><para>
    /// This is prerelease documentation for the RDS Database Proxy feature in preview release.
    /// It is subject to change.
    /// </para></note><para>
    /// Associate one or more <code>DBProxyTarget</code> data structures with a <code>DBProxyTargetGroup</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "RDSDBProxyTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBProxyTarget")]
    [AWSCmdlet("Calls the Amazon Relational Database Service RegisterDBProxyTargets API operation.", Operation = new[] {"RegisterDBProxyTargets"}, SelectReturnType = typeof(Amazon.RDS.Model.RegisterDBProxyTargetsResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBProxyTarget or Amazon.RDS.Model.RegisterDBProxyTargetsResponse",
        "This cmdlet returns a collection of Amazon.RDS.Model.DBProxyTarget objects.",
        "The service call response (type Amazon.RDS.Model.RegisterDBProxyTargetsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterRDSDBProxyTargetCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>One or more DB cluster identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DBClusterIdentifiers")]
        public System.String[] DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>One or more DB instance identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DBInstanceIdentifiers")]
        public System.String[] DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DBProxyName
        /// <summary>
        /// <para>
        /// <para>The identifier of the <code>DBProxy</code> that is associated with the <code>DBProxyTargetGroup</code>.</para>
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
        public System.String DBProxyName { get; set; }
        #endregion
        
        #region Parameter TargetGroupName
        /// <summary>
        /// <para>
        /// <para>The identifier of the <code>DBProxyTargetGroup</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetGroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBProxyTargets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.RegisterDBProxyTargetsResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.RegisterDBProxyTargetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBProxyTargets";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBProxyName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBProxyName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBProxyName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBProxyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-RDSDBProxyTarget (RegisterDBProxyTargets)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.RegisterDBProxyTargetsResponse, RegisterRDSDBProxyTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBProxyName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DBClusterIdentifier != null)
            {
                context.DBClusterIdentifier = new List<System.String>(this.DBClusterIdentifier);
            }
            if (this.DBInstanceIdentifier != null)
            {
                context.DBInstanceIdentifier = new List<System.String>(this.DBInstanceIdentifier);
            }
            context.DBProxyName = this.DBProxyName;
            #if MODULAR
            if (this.DBProxyName == null && ParameterWasBound(nameof(this.DBProxyName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBProxyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetGroupName = this.TargetGroupName;
            
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
            var request = new Amazon.RDS.Model.RegisterDBProxyTargetsRequest();
            
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifiers = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifiers = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.DBProxyName != null)
            {
                request.DBProxyName = cmdletContext.DBProxyName;
            }
            if (cmdletContext.TargetGroupName != null)
            {
                request.TargetGroupName = cmdletContext.TargetGroupName;
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
        
        private Amazon.RDS.Model.RegisterDBProxyTargetsResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.RegisterDBProxyTargetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "RegisterDBProxyTargets");
            try
            {
                #if DESKTOP
                return client.RegisterDBProxyTargets(request);
                #elif CORECLR
                return client.RegisterDBProxyTargetsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DBClusterIdentifier { get; set; }
            public List<System.String> DBInstanceIdentifier { get; set; }
            public System.String DBProxyName { get; set; }
            public System.String TargetGroupName { get; set; }
            public System.Func<Amazon.RDS.Model.RegisterDBProxyTargetsResponse, RegisterRDSDBProxyTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBProxyTargets;
        }
        
    }
}
