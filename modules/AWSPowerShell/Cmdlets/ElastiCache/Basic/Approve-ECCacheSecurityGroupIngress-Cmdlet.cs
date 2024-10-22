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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Allows network ingress to a cache security group. Applications using ElastiCache must
    /// be running on Amazon EC2, and Amazon EC2 security groups are used as the authorization
    /// mechanism.
    /// 
    ///  <note><para>
    /// You cannot authorize ingress from an Amazon EC2 security group in one region to an
    /// ElastiCache cluster in another region.
    /// </para></note>
    /// </summary>
    [Cmdlet("Approve", "ECCacheSecurityGroupIngress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CacheSecurityGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache AuthorizeCacheSecurityGroupIngress API operation.", Operation = new[] {"AuthorizeCacheSecurityGroupIngress"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.AuthorizeCacheSecurityGroupIngressResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheSecurityGroup or Amazon.ElastiCache.Model.AuthorizeCacheSecurityGroupIngressResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.CacheSecurityGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.AuthorizeCacheSecurityGroupIngressResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ApproveECCacheSecurityGroupIngressCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CacheSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>The cache security group that allows network ingress.</para>
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
        public System.String CacheSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupName
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 security group to be authorized for ingress to the cache security group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EC2SecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EC2SecurityGroupOwnerId
        /// <summary>
        /// <para>
        /// <para>The Amazon account number of the Amazon EC2 security group owner. Note that this is
        /// not the same thing as an Amazon access key ID - you must provide a valid Amazon account
        /// number for this parameter.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EC2SecurityGroupOwnerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CacheSecurityGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.AuthorizeCacheSecurityGroupIngressResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.AuthorizeCacheSecurityGroupIngressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CacheSecurityGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CacheSecurityGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-ECCacheSecurityGroupIngress (AuthorizeCacheSecurityGroupIngress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.AuthorizeCacheSecurityGroupIngressResponse, ApproveECCacheSecurityGroupIngressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CacheSecurityGroupName = this.CacheSecurityGroupName;
            #if MODULAR
            if (this.CacheSecurityGroupName == null && ParameterWasBound(nameof(this.CacheSecurityGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheSecurityGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EC2SecurityGroupName = this.EC2SecurityGroupName;
            #if MODULAR
            if (this.EC2SecurityGroupName == null && ParameterWasBound(nameof(this.EC2SecurityGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter EC2SecurityGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EC2SecurityGroupOwnerId = this.EC2SecurityGroupOwnerId;
            #if MODULAR
            if (this.EC2SecurityGroupOwnerId == null && ParameterWasBound(nameof(this.EC2SecurityGroupOwnerId)))
            {
                WriteWarning("You are passing $null as a value for parameter EC2SecurityGroupOwnerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElastiCache.Model.AuthorizeCacheSecurityGroupIngressRequest();
            
            if (cmdletContext.CacheSecurityGroupName != null)
            {
                request.CacheSecurityGroupName = cmdletContext.CacheSecurityGroupName;
            }
            if (cmdletContext.EC2SecurityGroupName != null)
            {
                request.EC2SecurityGroupName = cmdletContext.EC2SecurityGroupName;
            }
            if (cmdletContext.EC2SecurityGroupOwnerId != null)
            {
                request.EC2SecurityGroupOwnerId = cmdletContext.EC2SecurityGroupOwnerId;
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
        
        private Amazon.ElastiCache.Model.AuthorizeCacheSecurityGroupIngressResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.AuthorizeCacheSecurityGroupIngressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "AuthorizeCacheSecurityGroupIngress");
            try
            {
                #if DESKTOP
                return client.AuthorizeCacheSecurityGroupIngress(request);
                #elif CORECLR
                return client.AuthorizeCacheSecurityGroupIngressAsync(request).GetAwaiter().GetResult();
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
            public System.String CacheSecurityGroupName { get; set; }
            public System.String EC2SecurityGroupName { get; set; }
            public System.String EC2SecurityGroupOwnerId { get; set; }
            public System.Func<Amazon.ElastiCache.Model.AuthorizeCacheSecurityGroupIngressResponse, ApproveECCacheSecurityGroupIngressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CacheSecurityGroup;
        }
        
    }
}
